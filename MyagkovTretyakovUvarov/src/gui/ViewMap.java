package gui;

import geom.Line2D;
import geom.Point2D;

import java.awt.BasicStroke;
import java.awt.Color;
import java.awt.Graphics;
import java.awt.Graphics2D;
import java.awt.Point;
import java.awt.RenderingHints;
import java.awt.event.MouseEvent;
import java.awt.event.MouseMotionListener;
import java.util.ArrayList;

import com.alee.laf.label.WebLabel;
import com.alee.laf.panel.WebPanel;
import com.alee.managers.tooltip.TooltipManager;

import data.BusRoute;
import data.BusStop;
import data.CityMap;
import data.Street;

public class ViewMap extends WebPanel {

	private static final long serialVersionUID = -2266756237475490659L;

	private static final Color background = new Color(69, 205, 123);
	private static final Color streetColor = Color.white;
	private static final Color stopColor = Color.red;
	private static final Color pathColor = Color.blue;
	private static final Color warningStopColor = Color.yellow;
	private static final Color newStopColor = Color.orange;
	private static final Color intersectionColor = Color.cyan;
	private static final Color selectColor = Color.darkGray;
	private static final Color highlightedRouteColor = Color.magenta;
	
	private static final int radius = 6;

	private final CityMap map;
	private final ArrayList<BusStop> busStops;
	private final WebLabel statusBarLabel;
	private final WebLabel tip;
	
	private ArrayList<BusRoute> busRoutes;

	
	public Point lastClickPoint;

	private boolean drawStops;
	private boolean drawIntersections;
	private boolean drawLine;
	private boolean changeStatus = true;
	private boolean drawRoute;
	private boolean drawNewStop;

	private BusRoute visibleRoute;
	
	private BusStop selectedStop;
	public BusStop clickedBusStop;
	public Point2D clickedPoint;
	public Point2D newStop;
	public BusRoute highlightedRoute;

	public ViewMap(CityMap map, ArrayList<BusStop> busStops,
			WebLabel statusBarLabel) {
		this.map = map;
		this.busStops = busStops;
		this.statusBarLabel = statusBarLabel;
		tip = new WebLabel();
		busRoutes = new ArrayList<>();
		drawStops = true;

		TooltipManager.setTooltip(statusBarLabel, tip);
		tip.setMargin(4);

		setBackground(background);
		addMouseMotionListener(new MouseMotionListener() {
			@Override
			public void mouseMoved(MouseEvent e) {
				repaint();
			}

			@Override
			public void mouseDragged(MouseEvent e) {
			}
		});

	}

	public boolean updateClickedPoints(Point p) {
		BusStop localClickedBusStop = null;
		Point2D localClickedPoint = null;
		for (BusStop stop : busStops) {
			int px = x(stop.getX());
			int py = y(stop.getY());
			if (sqr(px - p.x) + sqr(py - p.y) <= sqr(radius)) {
				localClickedBusStop = stop;
				localClickedPoint = stop.getPosition();
			}
		}
		if (localClickedPoint == null) {
			for (Point2D pnt : map.getIntersections()) {
				int px = x(pnt.getX());
				int py = y(pnt.getY());
				if (sqr(px - p.x) + sqr(py - p.y) <= sqr(radius)) {
					localClickedPoint = pnt;
				}
			}
		}
		if (localClickedPoint != null && validClickPoint(localClickedPoint)) {
			clickedBusStop = localClickedBusStop;
			clickedPoint = localClickedPoint;
			if (drawLine)
				lastClickPoint = new Point(x(localClickedPoint.getX()),
						y(localClickedPoint.getY()));
			return true;
		}
		return false;
	}

	@Override
	public void paint(Graphics g) {
		super.paint(g);
		
		if (changeStatus)
			setStatusText("");
		
		Point mousePosition = getMousePosition();
		Point2D mousePoint2d = mousePosition == null ? null : new Point2D(
				backX(mousePosition.x), backY(mousePosition.y));

		Graphics2D g2 = (Graphics2D) g;
		g2.setRenderingHint(RenderingHints.KEY_ANTIALIASING,
				RenderingHints.VALUE_ANTIALIAS_ON);
		g2.setBackground(background);

		ArrayList<Street> streets = map.getStreets();

		newStop = null;

		for (Street s : streets) {
			g2.setStroke(new BasicStroke(4f));
			g2.setColor(streetColor);
			Line2D segment = s.getSegment();
			int fx = x(segment.getFrom().getX());
			int fy = y(segment.getFrom().getY());
			int tx = x(segment.getTo().getX());
			int ty = y(segment.getTo().getY());
			g2.drawLine(fx, fy, tx, ty);
			if (drawNewStop && mousePoint2d != null) {
				if (segment.dist(mousePoint2d) < backX(5)) {
					Point2D p = segment.projectOnSegment(mousePoint2d);
					if (p != null) {
						newStop = p;
					}
				}
			}

		}

		if (drawIntersections) {
			for (Point2D p : map.getIntersections()) {
				int x = x(p.getX());
				int y = y(p.getY());
				Color color = intersectionColor;
				if (mousePosition != null) {
					if (sqr(x - mousePosition.x) + sqr(y - mousePosition.y) <= sqr(radius)
							&& validClickPoint(p))
						color = selectColor;
				}
				drawPoint(g2, p, color, false);
			}
		}
		
		if (drawNewStop) {
			if (newStop != null) {
				g2.setStroke(new BasicStroke(1f));
				drawPoint(g2, newStop, newStopColor, false);
			}
		}
		
		if (drawStops) {
			g2.setStroke(new BasicStroke(2.5f));
			for (BusStop stop : busStops) {

				int x = x(stop.getX());
				int y = y(stop.getY());
				Color color = stopColor;
				if (stop.getCntRoutes() == 0)
					color = warningStopColor;

				if (mousePosition != null) {
					if (sqr(x - mousePosition.x) + sqr(y - mousePosition.y) <= sqr(radius)
							&& validClickPoint(stop.getPosition()))
						color = selectColor;
				}
				boolean border = selectedStop != null
						&& selectedStop.getId() == stop.getId();
				drawPoint(g2, stop.getPosition(), color, border);
				if (changeStatus && color == selectColor) {
					setStatusText("Остановка \"" + stop + "\"");
				}
			}
		}

		if (drawLine) {
			if (mousePosition != null && lastClickPoint != null) {
				g2.setStroke(new BasicStroke(3.5f));
				// g2.setColor(new Color(255, 125, 255));
				g2.setColor(pathColor);
				g2.drawLine(lastClickPoint.x, lastClickPoint.y,
						mousePosition.x, mousePosition.y);
			}
		}
		if (drawRoute) {
			g2.setColor(pathColor);
			g2.setStroke(new BasicStroke(1.5f));
			if (visibleRoute == null) {
				for (BusRoute route : busRoutes) {
					if (highlightedRoute != null && route.equals(highlightedRoute))
						continue;
					
					ArrayList<Point2D> pnt = route.getPath();
					for (int i = 1; i < pnt.size(); i++) {
						Point2D prev = pnt.get(i - 1);
						Point2D cur = pnt.get(i);
						g2.drawLine(x(prev.getX()), y(prev.getY()),
								x(cur.getX()), y(cur.getY()));
					}
				}
				
				
				if (highlightedRoute != null) {
					g2.setStroke(new BasicStroke(4.5f));
					g2.setColor(highlightedRouteColor);
					ArrayList<Point2D> pnt = highlightedRoute.getPath();
					for (int i = 1; i < pnt.size(); i++) {
						Point2D prev = pnt.get(i - 1);
						Point2D cur = pnt.get(i);
						g2.drawLine(x(prev.getX()), y(prev.getY()), x(cur.getX()),
								y(cur.getY()));
					}
				}
				
			} else {
				ArrayList<Point2D> pnt = visibleRoute.getPath();
				for (int i = 1; i < pnt.size(); i++) {
					Point2D prev = pnt.get(i - 1);
					Point2D cur = pnt.get(i);
					g2.drawLine(x(prev.getX()), y(prev.getY()), x(cur.getX()),
							y(cur.getY()));
				}

			}
		}

	}

	public void setStatusText(String text) {
		if (statusBarLabel != null) {
			statusBarLabel.setText(text);
			tip.setText(text);
		}
	}

	private boolean validClickPoint(Point2D p) {
		if (!drawLine || clickedPoint == null)
			return true;

		if (clickedPoint.equals(p))
			return false;

		for (Street street : map.getStreets()) {
			if (street.getSegment().onSegment(clickedPoint)
					&& street.getSegment().onSegment(p)) {
				return true;
			}
		}

		return false;
	}

	private void drawPoint(Graphics2D g2, Point2D point, Color color,
			boolean border) {
		int x = x(point.getX());
		int y = y(point.getY());
		g2.setColor(color);
		g2.fillOval(x - radius, y - radius, 2 * radius, 2 * radius);
		if (border)
			g2.setColor(Color.black);
		g2.drawOval(x - radius, y - radius, 2 * radius, 2 * radius);
	}

	public Point2D getBackPoint(Point p) {
		return new Point2D(backX(p.x), backY(p.y));
	}

	public Point getPoint(Point2D p) {
		return new Point(x(p.getX()), y(p.getY()));
	}

	private int sqr(int x) {
		return x * x;
	}

	private double backX(int x) {
		return 1.0 * x / getWidth();
	}

	private double backY(int y) {
		return 1.0 * (getHeight() - y) / getHeight();
	}

	private int x(double x) {
		return (int) (this.getWidth() * x);
	}

	private int y(double y) {
		return (int) (this.getHeight() - this.getHeight() * y);
	}

	public void removeBusRoutes(int i) {
		busRoutes.remove(i);
		repaint();
	}

	public boolean isDrawIntersections() {
		return drawIntersections;
	}

	public void setDrawIntersections(boolean drawIntersections) {
		this.drawIntersections = drawIntersections;
	}

	public boolean isDrawRoute() {
		return drawRoute;
	}

	public void setDrawRoute(boolean drawRoute) {
		this.drawRoute = drawRoute;
		repaint();
	}

	public boolean isChangeStatus() {
		return changeStatus;
	}

	public void setChangeStatus(boolean changeStatus) {
		this.changeStatus = changeStatus;
	}
	
	public boolean isDrawLine() {
		return drawLine;
	}

	public void setDrawLine(boolean drawLine) {
		this.drawLine = drawLine;
	}

	public BusRoute getVisibleRoute() {
		return visibleRoute;
	}

	public void setVisibleRoute(BusRoute visibleRoute) {
		this.visibleRoute = visibleRoute;
		repaint();
	}

	public void setDrawNewStop(boolean value) {
		drawNewStop = value;
		repaint();
	}
	
	public boolean isDrawNewStop() {
		return drawNewStop;
	}

	public void setSelectedStop(BusStop stop) {
		selectedStop = stop;
		repaint();
	}

	public void setDrawStops(boolean value) {
		drawStops = value;
		repaint();
	}

	public boolean getDrawStops() {
		return drawStops;
	}

	public void setBusRoutes(ArrayList<BusRoute> busRoutes) {
		this.busRoutes = new ArrayList<>(busRoutes);
		repaint();
	}
	
}
