package gui.frame;

import java.awt.Component;
import java.awt.Font;
import java.awt.GridBagConstraints;
import java.awt.GridBagLayout;
import java.awt.Insets;
import java.awt.KeyEventDispatcher;
import java.awt.KeyboardFocusManager;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.KeyEvent;

import javax.swing.ImageIcon;

import static utils.GUIConstants.zeroInsets;

import com.alee.laf.button.WebButton;
import com.alee.laf.label.WebLabel;
import com.alee.laf.rootpane.WebDialog;

public class AboutFrame extends WebDialog {

	private static final long serialVersionUID = -6889347210603189925L;
	private static final String title = "О программе";

	private final KeyEventDispatcher myKeyEventDispatcher = new KeyEventDispatcher() {
		
		@Override
		public boolean dispatchKeyEvent(KeyEvent e) {
			if (e.getID() == KeyEvent.KEY_RELEASED) {
				
				if (e.getKeyCode() == KeyEvent.VK_ESCAPE) {
					dispose();
				}
				
			}
			return false;
		}
	};
	
	private AboutFrame(Component owner) {
		super(owner);
		setTitle(title);
		setResizable(false);
		setLocationByPlatform(true);
		center(owner);
		KeyboardFocusManager.getCurrentKeyboardFocusManager().addKeyEventDispatcher(myKeyEventDispatcher);		
		setDefaultCloseOperation(DISPOSE_ON_CLOSE);

		ImageIcon icon = new ImageIcon(getClass().getResource("/content/pics/about.png"));
		
		WebLabel imageLabel = new WebLabel(icon);

		setLayout(new GridBagLayout());

		WebButton closeButton = new WebButton("Закрыть");

		closeButton.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e) {
				dispose();
			}
		});

		
		this.add(imageLabel, new GridBagConstraints(0, 0, 1, 5, 0.0, 1.0,
				GridBagConstraints.LINE_START, GridBagConstraints.NONE,
				zeroInsets, 0, 0));


		int row = 0;
		
		WebLabel label = new WebLabel("АРМ диспетчера автобусных маршрутов");

		
		this.add(new WebLabel("Курсовая работа на тему:"), new GridBagConstraints(1, row++, 2, 1, 1.0, 0.0,
				GridBagConstraints.CENTER, GridBagConstraints.NONE,
				new Insets(10, 10, 0, 10), 0, 0));

		
		label.setFont(new Font("Arial", Font.BOLD, 14));
		
		this.add(label, new GridBagConstraints(1, row++, 2, 1, 1.0, 0.0,
				GridBagConstraints.CENTER, GridBagConstraints.NONE,
				new Insets(10, 10, 0, 10), 0, 0));
		
		
		this.add(new WebLabel("Версия: 1.0"), new GridBagConstraints(1, row++, 2, 1, 1.0, 0.0,
				GridBagConstraints.PAGE_START, GridBagConstraints.HORIZONTAL,
				new Insets(10, 10, 0, 10), 0, 0));
		
		this.add(new WebLabel("Автор: Уваров Дмитрий Андреевич, ПИ-02, 2013 год"), new GridBagConstraints(1, row++, 2, 1, 1.0, 0.0,
				GridBagConstraints.PAGE_START, GridBagConstraints.HORIZONTAL,
				new Insets(10, 10, 0, 10), 0, 0));
		
		this.add(closeButton, new GridBagConstraints(2, row++, 1, 1, 1.0, 0.0,
				GridBagConstraints.LINE_END, GridBagConstraints.NONE,
				new Insets(10, 10, 10, 10), 0, 0));
		
		setSize(550, icon.getIconHeight());
	}
	
	@Override
	public void dispose() {
		KeyboardFocusManager.getCurrentKeyboardFocusManager().removeKeyEventDispatcher(myKeyEventDispatcher);
		super.dispose();
	}

	public static void showDialog(Component owner) {
		AboutFrame aboutFrame = new AboutFrame(owner);
		aboutFrame.setModal(true);
		aboutFrame.setVisible(true);
	}

}
