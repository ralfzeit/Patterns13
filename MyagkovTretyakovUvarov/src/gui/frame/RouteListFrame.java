package gui.frame;

import static utils.GUIConstants.zeroInsets;

import java.awt.Component;
import java.awt.Dimension;
import java.awt.GridBagConstraints;
import java.awt.GridBagLayout;
import java.awt.Insets;
import java.awt.KeyEventDispatcher;
import java.awt.KeyboardFocusManager;
import java.awt.Toolkit;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.KeyEvent;
import java.awt.event.WindowEvent;
import java.util.ArrayList;

import com.alee.laf.button.WebButton;
import com.alee.laf.label.WebLabel;
import com.alee.laf.list.WebList;
import com.alee.laf.list.WebListModel;
import com.alee.laf.panel.WebPanel;
import com.alee.laf.rootpane.WebDialog;
import com.alee.laf.scroll.WebScrollPane;

import data.BusRoute;

public class RouteListFrame extends WebDialog {

	private static final long serialVersionUID = -7566892000050525405L;
	private static String frameTitle = "Список маршрутов";
	

	private RouteListFrame routeListFrame;
	
	private ArrayList<BusRoute> all;
	

	private ArrayList<BusRoute> current;

	private WebListModel<BusRoute> currentListModel = new WebListModel<>();
	private WebList currentList;
	private WebListModel<BusRoute> otherListModel = new WebListModel<>();
	private WebList otherList;
	
	private boolean result = false;;
	
	
	private final KeyEventDispatcher myKeyEventDispatcher = new KeyEventDispatcher() {
		
		@Override
		public boolean dispatchKeyEvent(KeyEvent e) {
			if (e.getID() == KeyEvent.KEY_RELEASED) {
				if (e.getKeyCode() == KeyEvent.VK_ESCAPE) {
					result = false;
					close();
				} else if (e.getKeyCode() == KeyEvent.VK_ENTER) {
					result = true;
					close();
				}
				
			}
			return false;
		}
	};
	
	

	private RouteListFrame(Component owner, ArrayList<BusRoute> current, ArrayList<BusRoute> all) {
		super(owner);
		KeyboardFocusManager.getCurrentKeyboardFocusManager().addKeyEventDispatcher(myKeyEventDispatcher);
		this.setTitle(frameTitle);
		this.current = current;
		this.all = all;
		routeListFrame = this;
		this.setResizable(false);
		this.setLocationRelativeTo(owner);
		this.setShowMinimizeButton(false);
		this.setShowMaximizeButton(false);
		this.setLayout(new GridBagLayout());

		final WebScrollPane scroll1 = new WebScrollPane(getCurrentList());
		final WebScrollPane scroll2 = new WebScrollPane(getOtherList());
		
		WebButton delButton = new WebButton(">");
		WebButton addButton = new WebButton("<");
		
		WebButton delAllButton = new WebButton(">>");
		WebButton addAllButton = new WebButton("<<");
		
		
		WebButton okButton = new WebButton("ОК");
		okButton.setActionCommand("ok");
		
		WebButton cancelButton = new WebButton("Отмена");
		cancelButton.setActionCommand("cancel");

		
		
		{//delButton
			delButton.addActionListener(new ActionListener() {
				@Override
				public void actionPerformed(ActionEvent e) {
					int[] idx = currentList.getSelectedIndices();
					for (int i = idx.length - 1; i >= 0; i--) {
						otherListModel.addElement(currentListModel.remove(idx[i]));
						routeListFrame.current.remove(idx[i]);
					}
				}
			});
		}
		
		
		
		{//addButton
			addButton.addActionListener(new ActionListener() {
				@Override
				public void actionPerformed(ActionEvent e) {
					int[] idx = otherList.getSelectedIndices();
					for (int i = idx.length - 1; i >= 0; i--) {
						BusRoute s = otherListModel.remove(idx[i]);
						currentListModel.addElement(s);
						routeListFrame.current.add(s);
					}
				}
			});
		}
		
		delAllButton.addActionListener(new ActionListener() {
			
			@Override
			public void actionPerformed(ActionEvent e) {
				while (currentListModel.size() > 0) {
					routeListFrame.current.remove(0);
					otherListModel.addElement(currentListModel.remove(0));
				}
			}
		});
		
		addAllButton.addActionListener(new ActionListener() {
			
			@Override
			public void actionPerformed(ActionEvent e) {
				while (otherListModel.size() > 0) {
					BusRoute s = otherListModel.remove(0);
					routeListFrame.current.add(s);
					currentListModel.addElement(s);
				}
			}
		});
		
		

		ActionListener closeListener = new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e) {
				String command = e.getActionCommand();
				result = "ok".equals(command);
				close();
			}
		};
		
		okButton.addActionListener(closeListener);
		cancelButton.addActionListener(closeListener);
		
		
		this.add(new WebLabel("Отображаемые маршруты:"), new GridBagConstraints(0, 0, 1, 1, 0.0, 0.0,
				GridBagConstraints.LINE_START, GridBagConstraints.HORIZONTAL,
				new Insets(10, 10, 0, 5), 0, 0));
		
		this.add(new WebLabel("Остальные маршруты:"), new GridBagConstraints(2, 0, 2, 1, 0.0, 0.0,
				GridBagConstraints.LINE_START, GridBagConstraints.HORIZONTAL,
				new Insets(10, 5, 0, 10), 0, 0));

		Dimension scrollDimension = new Dimension(208, 260);
		
		{//currentList
			WebScrollPane scroll = scroll1;
			scroll.setMinimumSize(scrollDimension);
			scroll.setPreferredSize(scrollDimension);
			scroll.setSize(scrollDimension);
			this.add(scroll,
					new GridBagConstraints(0, 1, 1, 4, 0.5, 1.0,
					GridBagConstraints.CENTER, GridBagConstraints.NONE,
					new Insets(0, 10, 0, 5), 0, 0));
		}
		
		{//otherList
			WebScrollPane scroll = scroll2;
			scroll.setMinimumSize(scrollDimension);
			scroll.setPreferredSize(scrollDimension);
			scroll.setSize(scrollDimension);
			this.add(scroll,
					new GridBagConstraints(2, 1, 2, 4, 0.5, 1.0,
					GridBagConstraints.CENTER, GridBagConstraints.NONE,
					new Insets(0, 5, 0, 10), 0, 0));
		}
		
		this.add(delButton,
				new GridBagConstraints(1, 1, 1, 1, 0.0, 0.25,
				GridBagConstraints.PAGE_END, GridBagConstraints.HORIZONTAL,
				new Insets(5, 5, 0, 5), 0, 0));
		
		this.add(addButton,
				new GridBagConstraints(1, 2, 1, 1, 0.0, 0.25,
				GridBagConstraints.PAGE_START, GridBagConstraints.HORIZONTAL,
				new Insets(5, 5, 0, 5), 0, 0));
		
		this.add(delAllButton,
				new GridBagConstraints(1, 3, 1, 1, 0.0, 0.25,
				GridBagConstraints.PAGE_END, GridBagConstraints.HORIZONTAL,
				new Insets(5, 5, 0, 5), 0, 0));
		
		this.add(addAllButton,
				new GridBagConstraints(1, 4, 1, 1, 0.0, 0.25,
				GridBagConstraints.PAGE_START, GridBagConstraints.HORIZONTAL,
				new Insets(5, 5, 0, 5), 0, 0));
		
		this.add(new WebPanel(),
				new GridBagConstraints(0, 5, 2, 1, 0.0, 0.0,
				GridBagConstraints.LINE_START, GridBagConstraints.HORIZONTAL,
				zeroInsets, 0, 0));
		
		this.add(okButton,
				new GridBagConstraints(2, 5, 1, 1, 0.5, 0.0,
				GridBagConstraints.CENTER, GridBagConstraints.HORIZONTAL,
				new Insets(10, 5, 0, 5), 0, 0));
		
		this.add(cancelButton,
				new GridBagConstraints(3, 5, 1, 1, 0.5, 0.0,
				GridBagConstraints.LINE_END, GridBagConstraints.HORIZONTAL,
				new Insets(10, 5, 0, 10), 0, 0));
		
		this.setPreferredSize(new Dimension(500, 350));
		this.setSize(new Dimension(500, 350));
		this.setDefaultCloseOperation(DISPOSE_ON_CLOSE);
	}
	
	@Override
	public void dispose() {
		KeyboardFocusManager.getCurrentKeyboardFocusManager().removeKeyEventDispatcher(myKeyEventDispatcher);
		super.dispose();
	}
	
	private void close() {
		WindowEvent wev = new WindowEvent(this, WindowEvent.WINDOW_CLOSING);
		Toolkit.getDefaultToolkit().getSystemEventQueue().postEvent(wev);

	}

	private WebList getOtherList() {
		for (BusRoute s : all) {
			if (!current.contains(s))
				otherListModel.addElement(s);
		}
		
		otherList = new WebList(otherListModel);
		return otherList;
	}

	private WebList getCurrentList() {
		currentListModel.addElements(current);
		
		currentList = new WebList(currentListModel);
		return currentList;
	}
	
	public static boolean showDialog(Component owner, ArrayList<BusRoute> current, ArrayList<BusRoute> all) {
		RouteListFrame frame = new RouteListFrame(owner, current, all);
		frame.setModal(true);
		frame.setVisible(true);
		return frame.result;
	}

}
