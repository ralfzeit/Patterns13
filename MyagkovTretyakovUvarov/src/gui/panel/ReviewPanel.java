package gui.panel;

import static utils.GUIConstants.zeroInsets;
import gui.ViewMap;
import gui.frame.RouteListFrame;

import java.awt.GridBagConstraints;
import java.awt.GridBagLayout;
import java.awt.Insets;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.ComponentEvent;
import java.awt.event.ComponentListener;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;

import javax.swing.ListSelectionModel;
import javax.swing.event.ListSelectionEvent;
import javax.swing.event.ListSelectionListener;
import javax.swing.table.DefaultTableModel;

import utils.GUIConstants;
import utils.Pair;
import utils.Time;

import com.alee.laf.button.WebButton;
import com.alee.laf.checkbox.WebCheckBox;
import com.alee.laf.label.WebLabel;
import com.alee.laf.list.WebList;
import com.alee.laf.list.WebListModel;
import com.alee.laf.panel.WebPanel;
import com.alee.laf.scroll.WebScrollPane;
import com.alee.laf.table.WebTable;

import data.BusRoute;
import data.BusStop;
import data.City;

public class ReviewPanel extends WebPanel implements ComponentListener {

	private static final long serialVersionUID = 1968362702948690283L;

	private final int leftInset = 10;
	private final int rightInset = 10;
	private final int betweenInset = 10;
	private final int topInset = 10;

	private final City city;
	private final ViewMap viewMap;
	private final WebListModel<BusRoute> routesListModel = new WebListModel<>();
	private final WebList list;

	private final WebCheckBox showStops;

	final DefaultTableModel tableModel = new DefaultTableModel() {
		
		private static final long serialVersionUID = -5533425643317133521L;

		@Override
		public boolean isCellEditable(int row, int column) {
			return false;
		};

	};
	
	public ReviewPanel(final ViewMap viewMap, final City city) {

		this.city = city;
		this.viewMap = viewMap;

		list = new WebList(routesListModel);
		list.setVisibleRowCount(5);
		
		list.setSelectionMode(ListSelectionModel.SINGLE_SELECTION);
		
		list.addListSelectionListener(new ListSelectionListener() {
			
			@Override
			public void valueChanged(ListSelectionEvent e) {
				BusRoute route = (BusRoute) list.getSelectedValue();
				viewMap.highlightedRoute = route;
				changeRoute(route);
				viewMap.repaint();
			}
		});
		routesListModel.addElements(city.getBusRoutes());
		WebScrollPane scroll = new WebScrollPane(list);
		scroll.setMinimumHeight(20);

		viewMap.setBusRoutes(city.getBusRoutes());

		WebButton editButton = new WebButton("Настройки");
		WebButton removeButton = new WebButton("Удалить");

		{// addButton

			editButton.addActionListener(new ActionListener() {
				@Override
				public void actionPerformed(ActionEvent e) {
					ArrayList<BusRoute> current = new ArrayList<>(
							routesListModel.getSize());
					for (int i = 0; i < routesListModel.getSize(); i++)
						current.add(routesListModel.get(i));

					if (RouteListFrame.showDialog(getRootPane(), current,
							city.getBusRoutes())) {
						routesListModel.removeAllElements();
						Collections.sort(current, new Comparator<BusRoute>() {
							@Override
							public int compare(BusRoute br1, BusRoute br2) {
								return Integer.compare(br1.getId(), br2.getId());
							}
						});

						if (current.size() != 0)
							routesListModel.addElements(current);
						else
							routesListModel.clear();
						viewMap.setBusRoutes(current);
					}
				}
			});

		}

		removeButton.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e) {
				int[] idx = list.getSelectedIndices();
				for (int i = idx.length - 1; i >= 0; i--) {
					routesListModel.removeElementAt(idx[i]);
					viewMap.removeBusRoutes(idx[i]);
				}
			}
		});

		showStops = new WebCheckBox("Отображать остановки", true);

		showStops.addActionListener(new ActionListener() {

			@Override
			public void actionPerformed(ActionEvent e) {
				viewMap.setDrawStops(showStops.isSelected());
			}
		});

		this.setLayout(new GridBagLayout());

		this.add(new WebLabel("Список отображаемых маршрутов:"),
				new GridBagConstraints(0, 0, 1, 1, 1.0, 0.0,
						GridBagConstraints.PAGE_START,
						GridBagConstraints.HORIZONTAL, new Insets(topInset,
								leftInset, 0, rightInset), 0, 0));

		this.add(scroll, new GridBagConstraints(0, 1, 1, 1, 1.0, 0.0,
				GridBagConstraints.CENTER, GridBagConstraints.BOTH, new Insets(
						0, leftInset, 0, rightInset), 0, 0));

		this.add(editButton, new GridBagConstraints(0, 2, 1, 1, 0.5, 0.0,
				GridBagConstraints.PAGE_START, GridBagConstraints.HORIZONTAL,
				new Insets(betweenInset, leftInset, 0, rightInset), 0, 0));


		this.add(showStops, new GridBagConstraints(0, 3, 1, 1, 1.0, 0.0,
				GridBagConstraints.PAGE_START, GridBagConstraints.HORIZONTAL,
				new Insets(betweenInset, leftInset, 0, rightInset), 0, 0));

		
		this.add(new WebLabel("Маршрутный лист"), new GridBagConstraints(0, 4, 1, 1, 1.0, 0.0,
				GridBagConstraints.CENTER, GridBagConstraints.BOTH, new Insets(betweenInset, leftInset, 0, rightInset),
				0, 0));
		

		final WebTable table = new WebTable(tableModel);
		final WebScrollPane scrollTable = new WebScrollPane(table);
		
		table.setSelectionModel(GUIConstants.emptySelectionModel);
		
		this.add(scrollTable, new GridBagConstraints(0, 5, 1, 1, 1.0, 1.0,
				GridBagConstraints.CENTER, GridBagConstraints.BOTH, new Insets(0, leftInset, 0, rightInset),
				0, 0));

		
		this.add(new WebPanel(), new GridBagConstraints(0, 6, 1, 1, 1.0, 1.0,
				GridBagConstraints.CENTER, GridBagConstraints.BOTH, zeroInsets,
				0, 0));

		this.addComponentListener(this);
	}

	private void updateList() {
		ArrayList<BusRoute> cityRoutes = city.getBusRoutes();
		for (int i = routesListModel.getSize() - 1; i >= 0; i--) {
			BusRoute route = (BusRoute) routesListModel.elementAt(i);
			if (!cityRoutes.contains(route)) {
				routesListModel.remove(i);
				viewMap.removeBusRoutes(i);
			}
		}
	}
	
	private void changeRoute(BusRoute route) {
		while (tableModel.getRowCount() > 0) {
			tableModel.removeRow(0);
		}
		
		if (route == null) {
			tableModel.setColumnIdentifiers(new String[]{});
			return;
		}
		
		BusStop first = city.getBusStopById(route.getBusStopId(0));
		BusStop last = city.getBusStopById(route.getBusStopId(route.getCountBusStop() - 1));
		
		if (first == null) {
			tableModel.setColumnIdentifiers(new String[] {"Остановка"});
			tableModel.addRow(new String[]{"Маршрут не имеет остановок"});
			return;
		}
		
		String firstName = first == null ? "" : first.toString();
		String lastName = last == null ? "" : last.toString();
		
		tableModel.setColumnIdentifiers(new String[] {"Остановка", "Время от " + firstName, "Время от " + lastName});
		
		route.updateTimetable();

		ArrayList<Pair<BusStop, Pair<Time, Time>>> t = route.getPathList();
		
		for (Pair<BusStop, Pair<Time, Time>> p : t) {
			tableModel.addRow(new Object[] { p.getFirst(), p.getSecond().getFirst(), p.getSecond().getSecond() });
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
		if (e.getSource() == this)
			viewMap.highlightedRoute = (BusRoute) list.getSelectedValue();
		viewMap.setDrawRoute(true);
		viewMap.setDrawStops(showStops.isSelected());
		viewMap.setSelectedStop(null);
		viewMap.setVisibleRoute(null);
		updateList();
	}

	@Override
	public void componentHidden(ComponentEvent e) {
		if (e.getSource() == this) {
			viewMap.highlightedRoute = null;
			viewMap.repaint();
		}
	}

}
