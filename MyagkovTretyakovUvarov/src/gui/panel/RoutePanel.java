package gui.panel;

import geom.Point2D;
import gui.ViewMap;

import java.awt.GridBagConstraints;
import java.awt.GridBagLayout;
import java.awt.Insets;
import java.awt.KeyEventDispatcher;
import java.awt.KeyboardFocusManager;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.ComponentEvent;
import java.awt.event.ComponentListener;
import java.awt.event.KeyEvent;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import java.util.ArrayList;

import javax.swing.JOptionPane;
import javax.swing.ListSelectionModel;
import javax.swing.event.ListSelectionEvent;
import javax.swing.event.ListSelectionListener;

import com.alee.laf.button.WebButton;
import com.alee.laf.label.WebLabel;
import com.alee.laf.list.WebList;
import com.alee.laf.list.WebListModel;
import com.alee.laf.optionpane.WebOptionPane;
import com.alee.laf.panel.WebPanel;
import com.alee.laf.scroll.WebScrollPane;

import data.BusRoute;
import data.BusStop;
import data.City;

public class RoutePanel extends WebPanel implements ComponentListener {

	private static final long serialVersionUID = 9054781261890410709L;

	final int leftInset = 10;
	final int rightInset = 10;
	final int betweenInset = 10;
	final int topInset = 10;
	final int bottomInset = 10;

	final ViewMap viewMap;
	final City city;

	final WebListModel<BusRoute> routeListModel;
	final WebList routeList;
	final WebListModel<BusStop> stopListModel;

	final MouseListener viewMapMouseListener = new MouseListener() {
		@Override
		public void mouseReleased(MouseEvent e) {
		}

		@Override
		public void mousePressed(MouseEvent e) {
		}

		@Override
		public void mouseExited(MouseEvent e) {
		}

		@Override
		public void mouseEntered(MouseEvent e) {
		}

		@Override
		public void mouseClicked(MouseEvent e) {
			if (e.getButton() == MouseEvent.BUTTON3) {
				if (!isViewMode) {
					changeSaveButton.doClick();
				}
			}

			if (!viewMap.updateClickedPoints(e.getPoint()))
				return;
			if (!viewMap.isDrawIntersections()) {
				stopList.setSelectedValue(viewMap.clickedBusStop, true);
				return;
			}

			if (e.getButton() == MouseEvent.BUTTON1) {
				if (viewMap.clickedPoint != null) {
					BusRoute route = (BusRoute) routeList.getSelectedValue();
					if (viewMap.clickedBusStop != null) {
						route.stops.add(viewMap.clickedBusStop.getId());
						viewMap.clickedBusStop.incCntRoutes();
						addBusStopsToList(route);
					}
					route.path.add(viewMap.clickedPoint);
					route.updateTimetable();
				}
			}

		}
	};

	final ActionListener addRemoveAction = new ActionListener() {

		@Override
		public void actionPerformed(ActionEvent e) {
			String command = e.getActionCommand();
			if ("remove".equals(command)) {
				if (routeList.getSelectedIndex() != -1) {
					city.removeBusRoute((BusRoute) routeList.getSelectedValue());
					routeListModel.removeElementAt(routeList.getSelectedIndex());
					addBusStopsToList(routeList.getSelectedValue());
				}
			} else if ("add".equals(command)) {
				String name = JOptionPane.showInputDialog(getRootPane(),
						"Введите название нового маршрута", "");
				if (name != null && name.trim().length() > 0) {
					name = name.trim();
					BusRoute route = new BusRoute(name, city);
					city.addRoute(route);
					routeListModel.addElement(route);
					routeList.setSelectedValue(route, true);
				}
			}
		}
	};

	final ActionListener chageSaveCancelListener = new ActionListener() {

		@Override
		public void actionPerformed(ActionEvent e) {
			String command = e.getActionCommand();
			if ("change".equals(command)) {
				setChangeMode();
				// path.clear();
				// stops.clear();
				BusRoute route = (BusRoute) routeList.getSelectedValue();
				for (int id : route.stops)
					city.getBusStopById(id).decCntRoutes();

				oldBusStops.clear();
				oldPath.clear();
				oldBusStops.addAll(route.stops);
				oldPath.addAll(route.path);
				stopListModel.removeAllElements();
				route.stops.clear();
				route.path.clear();
				route.updateTimetable();
			} else if ("save".equals(command)) {
				setViewMode();
			} else if ("cancel".equals(command)) {
				if (cancel())
					setViewMode();
			}
		}
	};

	final KeyEventDispatcher myKeyEventDispatcher = new KeyEventDispatcher() {

		@Override
		public boolean dispatchKeyEvent(KeyEvent e) {
			if (e.getID() == KeyEvent.KEY_RELEASED) {

				if (e.getKeyCode() == KeyEvent.VK_ESCAPE) {
					if (cancel()) {
						setViewMode();
					}
				} else if (e.getKeyCode() == KeyEvent.VK_DELETE
						|| e.getKeyCode() == KeyEvent.VK_BACK_SPACE) {
					BusRoute route = (BusRoute) routeList.getSelectedValue();
					Point2D p = route.path.remove(route.path.size() - 1);
					if (city.getBusStopById(
							route.stops.get(route.stops.size() - 1))
							.getPosition().equals(p))
						route.stops.remove(route.stops.size() - 1);
					if (route.path.size() != 0) {
						Point2D lastPnt = route.path.get(route.path.size() - 1);
						viewMap.lastClickPoint = viewMap.getPoint(lastPnt);
						viewMap.clickedPoint = lastPnt;
						if (city.getBusStopById(
								route.stops.get(route.stops.size() - 1))
								.getPosition().equals(lastPnt))
							viewMap.clickedBusStop = city
									.getBusStopById(route.stops.get(route.stops
											.size() - 1));
						else
							viewMap.clickedBusStop = null;
					} else {
						viewMap.lastClickPoint = null;
						viewMap.clickedBusStop = null;
						viewMap.clickedPoint = null;
					}
					viewMap.repaint();
					route.updateTimetable();
				}

			}
			return false;
		}
	};

	private WebButton removeCancelButton;
	private WebButton addButton;
	private WebButton changeSaveButton;
	private WebButton renameButton;

	private boolean isViewMode = true;

	private ArrayList<Integer> oldBusStops = new ArrayList<>();
	private ArrayList<Point2D> oldPath = new ArrayList<>();

	private WebList stopList;

	public RoutePanel(final ViewMap viewMap, final City city) {

		this.viewMap = viewMap;
		this.city = city;

		routeListModel = new WebListModel<>();

		for (BusRoute route : city.getBusRoutes()) {
			routeListModel.addElement(route);
		}

		routeList = new WebList(routeListModel);
		stopListModel = new WebListModel<>();
		stopList = new WebList(stopListModel);

		routeList.setSelectedIndex(0);
		routeList.setSelectedIndex(ListSelectionModel.SINGLE_SELECTION);
		
		stopList.setSelectionMode(ListSelectionModel.SINGLE_SELECTION);

		stopList.addListSelectionListener(new ListSelectionListener() {
			@Override
			public void valueChanged(ListSelectionEvent e) {
				viewMap.setSelectedStop((BusStop) stopList.getSelectedValue());
			}
		});

		final WebScrollPane scroll = new WebScrollPane(stopList);

		changeSaveButton = new WebButton("Изменить");
		removeCancelButton = new WebButton("Удалить");
		addButton = new WebButton("Добавить");
		renameButton = new WebButton("Переименовать");

		changeSaveButton.setActionCommand("change");
		removeCancelButton.setActionCommand("remove");
		addButton.setActionCommand("add");

		routeList.addListSelectionListener(new ListSelectionListener() {
			@Override
			public void valueChanged(ListSelectionEvent e) {
				Object obj = routeList.getSelectedValue();
				addBusStopsToList(obj);
				if (obj == null) {
					viewMap.setDrawRoute(false);
				} else {
					viewMap.setVisibleRoute((BusRoute) obj);
					viewMap.setDrawRoute(true);
				}
			}
		});

		renameButton.addActionListener(new ActionListener() {

			@Override
			public void actionPerformed(ActionEvent e) {
				BusRoute route = (BusRoute) routeList.getSelectedValue();
				String oldName = route.getName();
				String newName = WebOptionPane.showInputDialog(getRootPane(),
						"Введите новое название маршрута:", oldName);
				if (newName != null) {
					route.setName(newName.trim());
					routeList.repaint();
				}
			}
		});

		removeCancelButton.addActionListener(addRemoveAction);
		addButton.addActionListener(addRemoveAction);

		changeSaveButton.addActionListener(chageSaveCancelListener);
		removeCancelButton.addActionListener(chageSaveCancelListener);

		this.setLayout(new GridBagLayout());
		int rowNum = 0;

		this.add(new WebLabel("Маршрут:"), new GridBagConstraints(0, rowNum++, 1,
				1, 0.5, 0.0, GridBagConstraints.LINE_END,
				GridBagConstraints.HORIZONTAL, new Insets(topInset, leftInset,
						0, rightInset), 0, 0));

		this.add(new WebScrollPane(routeList), new GridBagConstraints(0, rowNum, 1, 4, 0.5, 0.0,
				GridBagConstraints.LINE_START, GridBagConstraints.HORIZONTAL,
				new Insets(0, leftInset, 0, rightInset), 0, 0));

		this.add(changeSaveButton, new GridBagConstraints(1, rowNum++, 1, 1,
				0.0, 0.0, GridBagConstraints.PAGE_START,
				GridBagConstraints.HORIZONTAL, new Insets(0, 5, 0, rightInset),
				0, 0));

		this.add(removeCancelButton, new GridBagConstraints(1, rowNum++, 1, 1,
				0.0, 0.0, GridBagConstraints.PAGE_START,
				GridBagConstraints.HORIZONTAL, new Insets(betweenInset, 5, 0,
						rightInset), 0, 0));

		this.add(addButton, new GridBagConstraints(1, rowNum++, 1, 1, 0.0, 0.0,
				GridBagConstraints.PAGE_START,
				GridBagConstraints.HORIZONTAL, new Insets(betweenInset, 5, 0,
						rightInset), 0, 0));

		this.add(renameButton, new GridBagConstraints(1, rowNum++, 1, 1, 0.0,
				0.0, GridBagConstraints.PAGE_START,
				GridBagConstraints.HORIZONTAL, new Insets(betweenInset, 5, 0,
						rightInset), 0, 0));

		this.add(new WebLabel("Остановки:"), new GridBagConstraints(0,
				rowNum++, 1, 1, 1.0, 0.0, GridBagConstraints.PAGE_START,
				GridBagConstraints.HORIZONTAL, new Insets(betweenInset,
						leftInset, 0, rightInset), 0, 0));

		this.add(scroll, new GridBagConstraints(0, rowNum++, 2, 1, 1.0, 0.5,
				GridBagConstraints.CENTER, GridBagConstraints.BOTH, new Insets(
						0, leftInset, 0, rightInset), 0, 0));

		
		this.add(new WebPanel(), new GridBagConstraints(0, rowNum++, 2, 1, 0.5,
				1.0, GridBagConstraints.PAGE_END,
				GridBagConstraints.HORIZONTAL, new Insets(0, leftInset,
						bottomInset, rightInset), 0, 0));

		this.addComponentListener(this);
	}

	private void setChangeMode() {
		isViewMode = false;
		changeSaveButton.setActionCommand("save");
		changeSaveButton.setText("Сохранить");

		removeCancelButton.setActionCommand("cancel");
		removeCancelButton.setText("Отмена");

		routeList.setEnabled(false);
		addButton.setEnabled(false);
		renameButton.setEnabled(false);

		viewMap.lastClickPoint = null;
		viewMap.clickedBusStop = null;
		viewMap.clickedPoint = null;
		viewMap.setDrawLine(true);
		viewMap.setDrawIntersections(true);
		viewMap.repaint();
	}

	private void setViewMode() {
		isViewMode = true;

		changeSaveButton.setActionCommand("change");
		changeSaveButton.setText("Изменить");

		removeCancelButton.setActionCommand("remove");
		removeCancelButton.setText("Удалить");

		routeList.setEnabled(true);
		addButton.setEnabled(true);
		renameButton.setEnabled(true);

		viewMap.setDrawLine(false);
		viewMap.setDrawIntersections(false);
		viewMap.repaint();

	}

	private boolean cancel() {
		if (isViewMode)
			return true;

		if (WebOptionPane.showOptionDialog(getRootPane(),
				"Отменить изменения?", "Отмена", WebOptionPane.YES_NO_OPTION,
				WebOptionPane.QUESTION_MESSAGE, null, new Object[] { "Да",
						"Нет" }, "Да") == JOptionPane.NO_OPTION) {
			return false;
		}

		doCancel();
		return true;
	}

	private void doCancel() {
		if (isViewMode)
			return;
		BusRoute route = (BusRoute) routeList.getSelectedValue();

		for (int id : route.stops)
			city.getBusStopById(id).decCntRoutes();

		route.path.clear();
		route.stops.clear();

		route.path.addAll(oldPath);
		route.stops.addAll(oldBusStops);

		for (int id : route.stops)
			city.getBusStopById(id).incCntRoutes();
		route.updateTimetable();
		addBusStopsToList(route);
	}

	private void addBusStopsToList(Object route) {
		stopListModel.removeAllElements();
		if (route == null)
			return;

		BusRoute busRoute = (BusRoute) route;
		for (int i = 0; i < busRoute.getCountBusStop(); i++) {
			stopListModel.addElement(city.getBusStopById(busRoute.getBusStopId(i)));
		}
	}

	@Override
	public void componentResized(ComponentEvent e) {
	}

	@Override
	public void componentMoved(ComponentEvent e) {
	}

	@Override
	public void componentShown(ComponentEvent e) {
		viewMap.setDrawIntersections(false);
		viewMap.setSelectedStop(null);
		viewMap.setDrawRoute(true);
		viewMap.setVisibleRoute((BusRoute) routeList.getSelectedValue());
		viewMap.addMouseListener(viewMapMouseListener);

		addBusStopsToList(routeList.getSelectedValue());

		viewMap.setSelectedStop((BusStop) stopList.getSelectedValue());

		setViewMode();

		KeyboardFocusManager.getCurrentKeyboardFocusManager()
				.addKeyEventDispatcher(myKeyEventDispatcher);
	}

	@Override
	public void componentHidden(ComponentEvent e) {
		doCancel();
		setViewMode();
		viewMap.removeMouseListener(viewMapMouseListener);
		viewMap.setSelectedStop(null);
		KeyboardFocusManager.getCurrentKeyboardFocusManager()
				.removeKeyEventDispatcher(myKeyEventDispatcher);
	}

}
