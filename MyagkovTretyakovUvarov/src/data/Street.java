package data;

import geom.Line2D;
import geom.Point2D;

public class Street {
	
	private String name;
	private Line2D segment;

	public Street(String name, Line2D segment) {
		this.name = name;
		this.segment = segment;
	}
	
	public Street(String name, Point2D from, Point2D to) {
		this(name, new Line2D(from, to));
	}

	public String getName() {
		return name;
	}

	public Line2D getSegment() {
		return segment;
	}
	
	@Override
	public String toString() {
		return name + " " + segment;
	}
	
	
}
