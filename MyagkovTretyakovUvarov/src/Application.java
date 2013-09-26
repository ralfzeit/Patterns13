import gui.frame.MainFrame;

import javax.swing.SwingUtilities;

import com.alee.laf.WebLookAndFeel;

public class Application {

	public static void main(String[] args) {
		WebLookAndFeel.install();
		Runnable run = new Runnable() {
			@Override
			public void run() {
				new MainFrame();
			}
		};

		SwingUtilities.invokeLater(run);
	}
	
}
