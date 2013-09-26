package geom;

public class Line2D {
	private Point2D n;
	private double c;
	private Point2D from, to;
	
	public Line2D(Point2D from, Point2D to) {
		if (from.dist(to) < 1e-3)
			throw new IllegalArgumentException("from equal to");
		this.from = from;
		this.to = to;
		n = new Point2D(from.getY() - to.getY(), to.getX() - from.getX());
		c = -n.dot(from);
	}
	
	public Point2D getFrom() {
		return from;
	}
	
	public Point2D getTo() {
		return to;
	}
	
	public double f(Point2D p) {
		return n.dot(p) + c;
	}
	
	public double dist(Point2D p) {
		return Math.abs(f(p)) / n.len();
	}
	
	public Point2D crossLines(Line2D l) {
		double d  =  det(n.getX(), n.getY(), l.n.getX(), l.n.getY());
		if (Math.abs(d) < 1e-6)
			return null;
		double dx = -det(c, n.getY(), l.c, l.n.getY());
		double dy = -det(n.getX(), c, l.n.getX(), l.c);
		return new Point2D(dx / d, dy / d);
	}
	
	public boolean onSegment(Point2D p) {
		Point2D a = from.sub(p);
		Point2D b = to.sub(p);
		return a.dot(b) <= 0 && Math.abs(a.cross(b)) < 1e-6;
	}
	
	public Point2D crossSegments(Line2D s) {
		Point2D p = crossLines(s);
		if (p == null)
			return null;
		if (!onSegment(p) || !s.onSegment(p))
			return null;
		return p;
	}
	
	public Point2D projectOnLine(Point2D p) {
		double len = f(p) / n.len();
		return p.add(n.norm(len));
	}
	
	public Point2D projectOnSegment(Point2D p) {
		double len = -f(p) / n.len();
		Point2D project = p.add(n.norm(len));
		if (!onSegment(project))
			return null;
		return project;
	}
	
	private double det(double a11, double a12, double a21, double a22) {
		return a11 * a22 - a12 * a21;
	}
	
	@Override
	public String toString() {
		return from + " - " + to;
	}
}
