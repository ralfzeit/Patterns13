package data;

import geom.Point2D;

public class BusStop {

	private final int id;
	private String name;
	private Point2D position;
	private int cntRoutes;

	public BusStop(String name, Point2D position, int id) {
		this.name = name;
		this.position = position;
		this.id = id;
	}
	
	public int getId() {
		return id;
	}
	
	public String getName() {
		return name;
	}
	
	public void setName(String name) {
		this.name = name;
	}
	
	public double getX() {
		return position.getX();
	}
	
	public double getY() {
		return position.getY();
	}
	
	public int getCntRoutes() {
		return cntRoutes;
	}
	
	public void incCntRoutes() {
		cntRoutes++;
	}
	
	public void decCntRoutes() {
		cntRoutes--;
		if (cntRoutes < 0)
			throw new RuntimeException(name + " cntRoutes < 0");
	}
	
	@Override
	public boolean equals(Object obj) {
		if (!(obj instanceof BusStop))
			return false;
		BusStop stop = (BusStop) obj;
		return id == stop.id && name.equals(stop.name) && position.equals(stop.position);
	}
	
	@Override
	public String toString() {
		return name;
	}

	public Point2D getPosition() {
		return position;
	}
}
