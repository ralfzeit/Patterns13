package gui.frame;

import static utils.GUIConstants.zeroInsets;
import gui.ViewMap;
import gui.panel.ReviewPanel;
import gui.panel.RoutePanel;
import gui.panel.StopPanel;

import java.awt.Dimension;
import java.awt.GridBagConstraints;
import java.awt.GridBagLayout;
import java.awt.Toolkit;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.WindowEvent;
import java.io.IOException;

import javax.swing.ImageIcon;
import javax.swing.JFrame;
import javax.swing.JMenuBar;

import utils.SimpleSaver;

import com.alee.extended.panel.WebAccordion;
import com.alee.extended.statusbar.WebStatusBar;
import com.alee.laf.label.WebLabel;
import com.alee.laf.menu.WebMenu;
import com.alee.laf.menu.WebMenuBar;
import com.alee.laf.menu.WebMenuItem;
import com.alee.laf.optionpane.WebOptionPane;
import com.alee.laf.panel.WebPanel;
import com.alee.laf.rootpane.WebFrame;
import com.alee.managers.hotkey.Hotkey;

import data.City;

public class MainFrame extends WebFrame {

	private static final long serialVersionUID = -8026416994513756565L;
	private static final Dimension preferredSize = new Dimension(900, 500);
	private static final Dimension minimumSize = new Dimension(780, 370);
	private static final String appTitle = "АРМ диспетчера автобусных маршрутов";

	private final City city;

	private static WebFrame application = null;
	private final ViewMap viewMap;

	public MainFrame() {
		super(appTitle);
		City localCity = null;
		try {
			localCity = new SimpleSaver("content/data.txt").readCity();
		} catch (Throwable e) {
			e.printStackTrace();
			WebOptionPane.showOptionDialog(this, "Невозможно загрузить данные (content/data.txt).",
					"Ошибка", WebOptionPane.OK_OPTION,
					WebOptionPane.ERROR_MESSAGE, null, new String[] { "ОК" },
					"ОК");
			System.exit(13);
		}

		this.city = localCity;
		if (application != null)
			throw new RuntimeException();
		application = this;

		this.setDefaultCloseOperation(EXIT_ON_CLOSE);

		this.setExtendedState(this.getExtendedState() | JFrame.MAXIMIZED_BOTH);

		WebStatusBar statusBar = new WebStatusBar();
		final WebLabel statusBarLabel = new WebLabel();
		statusBar.addToMiddle(statusBarLabel);
		statusBar.setPreferredSize(new Dimension(0, 20));

		this.setLayout(new GridBagLayout());
		viewMap = new ViewMap(city.getMap(), city.getBusStops(), statusBarLabel);
		viewMap.setBusRoutes(city.getBusRoutes());
		viewMap.setDrawRoute(true);

		final WebAccordion accordion = new WebAccordion();
		accordion.setMultiplySelectionAllowed(false);
		accordion.setPreferredSize(new Dimension(300, 0));

		final WebPanel reviewPanel = new ReviewPanel(viewMap, city);
		final WebPanel routePanel = new RoutePanel(viewMap, city);
		final WebPanel stopPanel = new StopPanel(viewMap, city);

		accordion.addPane("Отображение", reviewPanel);
		accordion.addPane("Маршруты", routePanel);
		accordion.addPane("Остановки", stopPanel);

		this.add(viewMap, new GridBagConstraints(0, 0, 1, 1, 1.0, 1.0,
				GridBagConstraints.LINE_START, GridBagConstraints.BOTH,
				zeroInsets, 0, 0));

		this.add(statusBar, new GridBagConstraints(0, 1, 1, 1, 0.0, 0.0,
				GridBagConstraints.LINE_START, GridBagConstraints.HORIZONTAL,
				zeroInsets, 0, 0));

		this.add(accordion, new GridBagConstraints(1, 0, 1, 1, 0.0, 1.0,
				GridBagConstraints.LINE_END, GridBagConstraints.VERTICAL,
				zeroInsets, 0, 0));

		this.setJMenuBar(getMenu());

		this.setLocation(100, 100);
		this.setMinimumSize(minimumSize);
		this.setPreferredSize(preferredSize);
		this.setSize(preferredSize);
		this.setVisible(true);
		statusBarLabel.setText("status bar");
	}

	private ImageIcon loadIcon(String path) {
		java.net.URL imgURL = getClass().getResource(path);
		return new ImageIcon(imgURL);
	}

	private JMenuBar getMenu() {

		WebMenuBar menuBar = new WebMenuBar();

		WebMenu fileMenu = new WebMenu("Файл");

		ImageIcon saveIcon = loadIcon("/content/pics/save.png");
		ImageIcon exitIcon = loadIcon("/content/pics/exit.png");
		WebMenuItem save = new WebMenuItem("Сохранить", saveIcon);
		save.setHotkey(Hotkey.CTRL_S);
		save.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e) {
				try {
					new SimpleSaver("content/data.txt").writeCity(city);
				} catch (IOException e1) {
					WebOptionPane.showMessageDialog(application,
							"Невозможно сохранить.", "Ошибка",
							WebOptionPane.ERROR_MESSAGE);
				}
			}
		});

		WebMenuItem exit = new WebMenuItem("Выход", exitIcon);
		exit.setHotkey(Hotkey.ALT_F4);
		exit.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e) {
				close();
			}
		});
		
		WebMenu x = new WebMenu("TEST");
		
		x.add(new WebMenu("HAHA"));
		
		fileMenu.add(x);
		fileMenu.addSeparator();
		fileMenu.addSeparator();
		fileMenu.addSeparator();
		fileMenu.addSeparator();
		
		
		
		fileMenu.add(save);
		fileMenu.addSeparator();
		fileMenu.add(exit);
		

		WebMenu helpMenu = new WebMenu("Помощь");

		WebMenuItem about = new WebMenuItem("О программе");
		about.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e) {
				AboutFrame.showDialog(application);
			}
		});

		helpMenu.add(about);

		menuBar.add(fileMenu);
		menuBar.add(helpMenu);
		return menuBar;
	}

	void close() {
		WindowEvent wev = new WindowEvent(this, WindowEvent.WINDOW_CLOSING);
		Toolkit.getDefaultToolkit().getSystemEventQueue().postEvent(wev);
	}

}
