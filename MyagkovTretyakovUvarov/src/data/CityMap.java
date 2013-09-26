package data;

import geom.Point2D;

import java.util.ArrayList;

import static java.lang.Math.min;
import static java.lang.Math.max;

public class CityMap {
	

	private final double width;
	private final double height;
	private ArrayList<Street> streets = new ArrayList<>();
	private ArrayList<Point2D> intersections = new ArrayList<>();
	
	public CityMap(double width, double height) {
		this.width = width;
		this.height = height;
	}
	
	public ArrayList<Street> getStreets() {
		return new ArrayList<>(streets);
	}
	
	
	public void addStreet(Street newStreet) {
		lp: for (Street s : streets) {
			Point2D p = s.getSegment().crossSegments(newStreet.getSegment());
			if (p != null) {
				for (Point2D pnt : intersections)
					if (pnt.equals(p))
						continue lp;
				intersections.add(p);
			}
		}
		streets.add(newStreet);
	}
	
	public void normalaize() {
		double minX = Double.POSITIVE_INFINITY;
		double minY = Double.POSITIVE_INFINITY;
		
		double maxX = Double.NEGATIVE_INFINITY;
		double maxY = Double.NEGATIVE_INFINITY;
		
		for (Street s : streets) {
			Point2D from = s.getSegment().getFrom();
			Point2D to = s.getSegment().getTo();
			minX = min(minX, min(from.getX(), to.getX()));
			minY = min(minY, min(from.getY(), to.getY()));
			maxX = max(maxX, max(from.getX(), to.getX()));
			maxY = max(maxY, max(from.getY(), to.getY()));
		}

		double w = (maxX - minX);
		double h = (maxY - minY);
		
		minX -= w * 0.01;
		maxX += w * 0.01;

		minY -= h * 0.01;
		maxY += h * 0.01;
		
		Point2D minPoint = new Point2D(minX, minY);
		
		double scaleX = 1. / (maxX - minX);
		double scaleY = 1. / (maxY - minY);
		
		for (int i = 0; i < streets.size(); i++) {
			Street curStreet = streets.get(i);
			Point2D newFrom = curStreet.getSegment().getFrom().sub(minPoint);
			newFrom = new Point2D(newFrom.getX() * scaleX, newFrom.getY() * scaleY);
			
			Point2D newTo = curStreet.getSegment().getTo().sub(minPoint);
			newTo = new Point2D(newTo.getX() * scaleX, newTo.getY() * scaleY);
			streets.remove(i);
			streets.add(i, new Street(curStreet.getName(), newFrom, newTo));
		}
		
		for (int i = 0; i < intersections.size(); i++) {
			Point2D p = intersections.get(i).sub(minPoint);
			p = new Point2D(p.getX() * scaleX, p.getY() * scaleY);
			intersections.remove(i);
			intersections.add(i, p);
		}
		
	}
	
	public ArrayList<Point2D> getIntersections() {
		return new ArrayList<>(intersections);
	}

	public double getWidth() {
		return width;
	}

	public double getHeight() {
		return height;
	}

	
}
