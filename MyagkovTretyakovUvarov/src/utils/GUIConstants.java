package utils;

import java.awt.Insets;

import javax.swing.ListSelectionModel;
import javax.swing.event.ListSelectionListener;

public class GUIConstants {

	public final static Insets zeroInsets = new Insets(0, 0, 0, 0);

	public final static ListSelectionModel emptySelectionModel = new ListSelectionModel() {

		@Override
		public void setValueIsAdjusting(boolean valueIsAdjusting) {
		}

		@Override
		public void setSelectionMode(int selectionMode) {
		}

		@Override
		public void setSelectionInterval(int index0, int index1) {
		}

		@Override
		public void setLeadSelectionIndex(int index) {
		}

		@Override
		public void setAnchorSelectionIndex(int index) {
		}

		@Override
		public void removeSelectionInterval(int index0, int index1) {
		}

		@Override
		public void removeListSelectionListener(ListSelectionListener x) {
		}

		@Override
		public void removeIndexInterval(int index0, int index1) {
		}

		@Override
		public boolean isSelectionEmpty() {
			return false;
		}

		@Override
		public boolean isSelectedIndex(int index) {
			return false;
		}

		@Override
		public void insertIndexInterval(int index, int length, boolean before) {
		}

		@Override
		public boolean getValueIsAdjusting() {
			return false;
		}

		@Override
		public int getSelectionMode() {
			return 0;
		}

		@Override
		public int getMinSelectionIndex() {
			return 0;
		}

		@Override
		public int getMaxSelectionIndex() {
			return 0;
		}

		@Override
		public int getLeadSelectionIndex() {
			return 0;
		}

		@Override
		public int getAnchorSelectionIndex() {
			return 0;
		}

		@Override
		public void clearSelection() {
		}

		@Override
		public void addSelectionInterval(int index0, int index1) {
		}

		@Override
		public void addListSelectionListener(ListSelectionListener x) {
		}
	};

}
