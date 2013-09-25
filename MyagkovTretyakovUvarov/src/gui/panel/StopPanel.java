package gui.panel;

import static utils.GUIConstants.zeroInsets;
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

import javax.swing.DefaultComboBoxModel;
import javax.swing.DefaultListModel;
import javax.swing.JOptionPane;

import utils.GUIConstants;

import com.alee.laf.button.WebButton;
import com.alee.laf.combobox.WebComboBox;
import com.alee.laf.label.WebLabel;
import com.alee.laf.list.WebList;
import com.alee.laf.panel.WebPanel;
import com.alee.laf.scroll.WebScrollPane;

import data.BusRoute;
import data.BusStop;
import data.City;

public class StopPanel extends WebPanel implements ComponentListener {

	private static final long serialVersionUID = 6843106478860036913L;

	private final int leftInset = 10;
	private final int rightInset = 10;
	private final int betweenInset = 10;
	private final int topInset = 10;
	private final int bottomInset = 10;

	private final ViewMap viewMap;
	private final City city;

	private final WebComboBox comboBox;
	private final DefaultComboBoxModel<BusStop> comboBoxModel;
	private final DefaultListModel<BusRoute> listModel = new DefaultListModel<BusRoute>();

	private final MouseListener viewMapMouseListener = new MouseListener() {
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
			if (!viewMap.isDrawNewStop()) {
				viewMap.updateClickedPoints(e.getPoint());
				if (viewMap.clickedBusStop != null)
					comboBox.setSelectedItem(viewMap.clickedBusStop);
				return;
			}
			if (e.getButton() == MouseEvent.BUTTON3) {
				cancel();
			} else if (e.getButton() == MouseEvent.BUTTON1) {
				Point2D position = viewMap.newStop;
				if (position == null)
					return;
				String name = JOptionPane.showInputDialog(getRootPane(),
						"Введите название остановки:", "");
				if (name != null) {
					city.addBusStop(name, position);
					addBusStopToComboBox();
					comboBox.setSelectedIndex(comboBoxModel.getSize() - 1);
				}
				viewMap.setStatusText("");
				viewMap.setChangeStatus(true);
				viewMap.setDrawNewStop(false);
			}
		}
	};

	private final KeyEventDispatcher myKeyEventDispatcher = new KeyEventDispatcher() {
		
		@Override
		public boolean dispatchKeyEvent(KeyEvent e) {
			if (e.getID() == KeyEvent.KEY_RELEASED) {
				
				if (e.getKeyCode() == KeyEvent.VK_ESCAPE) {
					cancel();
				}
				
			}
			return false;
		}
	};
	
	public StopPanel(final ViewMap viewMap, final City city) {
		this.viewMap = viewMap;
		this.city = city;

		comboBoxModel = new DefaultComboBoxModel<>();

		comboBox = new WebComboBox(comboBoxModel);

		comboBox.addActionListener(new ActionListener() {

			@Override
			public void actionPerformed(ActionEvent e) {
				BusStop stop = (BusStop) comboBox.getSelectedItem();
				viewMap.setSelectedStop(stop);
				if (stop != null)
					addToList(stop);
			}
		});

		final WebButton renameButton = new WebButton("Переименовать");
		final WebButton removeButton = new WebButton("Удалить");
		final WebButton addButton = new WebButton("Добавить");

		renameButton.setActionCommand("rename");
		removeButton.setActionCommand("remove");
		addButton.setActionCommand("add");

		ActionListener click = new ActionListener() {

			@Override
			public void actionPerformed(ActionEvent e) {
				String command = e.getActionCommand();
				if ("rename".equals(command)) {
					BusStop stop = (BusStop) comboBoxModel.getSelectedItem();
					String oldName = stop.getName();
					String newName = JOptionPane.showInputDialog(getRootPane(),
							"Введите новое название остановки:", oldName);
					if (newName != null) {
						stop.setName(newName.trim());
						comboBox.repaint();
					}
				} else if ("add".equals(command)) {
					viewMap.setChangeStatus(false);
					viewMap.setStatusText("Укажите расположение остановки на карте. Для отмены нажмите Escape или правую кнопку мыши.");
					viewMap.setDrawNewStop(true);
				} else if ("remove".equals(command)) {
					if (!city.removeBusStop((BusStop) comboBoxModel
							.getSelectedItem())) {
						JOptionPane
								.showMessageDialog(
										getRootPane(),
										"Невозможно удалить остановку. Она исползуется в каком-то маршруте",
										"Ошибка", JOptionPane.ERROR_MESSAGE);
					} else {
						addBusStopToComboBox();
					}
				}
			}
		};

		renameButton.addActionListener(click);
		removeButton.addActionListener(click);
		addButton.addActionListener(click);

		this.addComponentListener(this);

		this.setLayout(new GridBagLayout());
		int rowNum = 0;

		this.add(new WebLabel("Название"), new GridBagConstraints(0, rowNum++,
				1, 1, 1.0, 0.0, GridBagConstraints.PAGE_START,
				GridBagConstraints.HORIZONTAL, new Insets(topInset, leftInset,
						0, rightInset), 0, 0));

		this.add(comboBox, new GridBagConstraints(0, rowNum++, 1, 1, 1.0, 0.0,
				GridBagConstraints.PAGE_START, GridBagConstraints.HORIZONTAL,
				new Insets(betweenInset, leftInset, 0, rightInset), 0, 0));

		this.add(renameButton, new GridBagConstraints(0, rowNum++, 1, 1, 1.0,
				0.0, GridBagConstraints.PAGE_START,
				GridBagConstraints.HORIZONTAL, new Insets(betweenInset,
						leftInset, 0, rightInset), 0, 0));

		this.add(removeButton, new GridBagConstraints(0, rowNum++, 1, 1, 1.0,
				0.0, GridBagConstraints.PAGE_START,
				GridBagConstraints.HORIZONTAL, new Insets(betweenInset,
						leftInset, 0, rightInset), 0, 0));


		this.add(new WebLabel("Маршруты, проходящие через остановку:"), new GridBagConstraints(0, rowNum++,
				1, 1, 1.0, 0.0, GridBagConstraints.LINE_START,
				GridBagConstraints.HORIZONTAL, new Insets(betweenInset,
						leftInset, 0, rightInset), 0, 0));

		final WebList listRoutes = new WebList(listModel);

		listRoutes.setSelectionModel(GUIConstants.emptySelectionModel);
		final WebScrollPane scroll = new WebScrollPane(listRoutes);

		this.add(scroll, new GridBagConstraints(0, rowNum++, 1, 1, 1.0, 0.5,
				GridBagConstraints.CENTER, GridBagConstraints.BOTH, new Insets(
						0, leftInset, 0, rightInset), 0, 0));

		this.add(new WebPanel(), new GridBagConstraints(0, rowNum++, 1, 1, 1.0,
				0.5, GridBagConstraints.CENTER, GridBagConstraints.BOTH,
				zeroInsets, 0, 0));

		this.add(addButton, new GridBagConstraints(0, rowNum++, 1, 1, 1.0, 0.0,
				GridBagConstraints.LINE_START, GridBagConstraints.HORIZONTAL,
				new Insets(0, leftInset, bottomInset, rightInset), 0, 0));
	}

	private void addToList(BusStop stop) {
		listModel.removeAllElements();
		if (stop == null)
			return;
		for (BusRoute route : city.getBusRotuesByStop(stop))
			listModel.addElement(route);		
	}

	private void addBusStopToComboBox() {
		comboBoxModel.removeAllElements();
		boolean add = true;
		for (BusStop stop : city.getBusStops()) {
			comboBoxModel.addElement(stop);
			if (add) {
				addToList(stop);
				add = false;
			}
		}
	}
	
	private void cancel() {

		viewMap.setStatusText("");
		viewMap.setChangeStatus(true);
		viewMap.setDrawNewStop(false);
	}

	@Override
	public void componentResized(ComponentEvent e) {
	}

	@Override
	public void componentMoved(ComponentEvent e) {
	}

	@Override
	public void componentShown(ComponentEvent e) {
		addBusStopToComboBox();
		viewMap.setDrawRoute(false);
		viewMap.addMouseListener(viewMapMouseListener);
		BusStop stop = (BusStop) comboBox.getSelectedItem();
		viewMap.setSelectedStop(stop);
		
		KeyboardFocusManager.getCurrentKeyboardFocusManager().addKeyEventDispatcher(myKeyEventDispatcher);
	}

	@Override
	public void componentHidden(ComponentEvent e) {
		viewMap.removeMouseListener(viewMapMouseListener);
		cancel();
		
		KeyboardFocusManager.getCurrentKeyboardFocusManager().removeKeyEventDispatcher(myKeyEventDispatcher);
	}

}
