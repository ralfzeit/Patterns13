package geom;

public class Point2D {
	private double x, y;

	public Point2D() {
		this(0, 0);
	}
	
	public Point2D(double x, double y) {
		this.x = x;
		this.y = y;
	}

	public double getX() {
		return x;
	}

	public double getY() {
		return y;
	}
	
	public Point2D add(Point2D p) {
		return new Point2D(x + p.x, y + p.y);
	}
	
	public Point2D mul(double k) {
		return new Point2D(x * k, y * k);
	}
	
	public double len2() {
		return x * x + y * y;
	}
	
	public double len() {
		return Math.sqrt(len2());
	}
	
	public double len2(double scaleX, double scaleY) {
		return x * x * scaleX * scaleX + y * y * scaleY * scaleY;
	}
	
	public double len(double scaleX, double scaleY) {
		return Math.sqrt(len2(scaleX, scaleY));
	}
	
	public Point2D sub(Point2D p) {
		return add(p.mul(-1));
	}
	
	public double dist2(Point2D p) {
		return sub(p).len2();
	}
	
	public double dist(Point2D p) {
		return sub(p).len();
	}
	
	public double dist(Point2D p, double scaleX, double scaleY) {
		return sub(p).len(scaleX, scaleY);
	}
	
	public Point2D norm(double len) {
		if (len() == 0)
			return this;
		return mul(len / len());
	}
	
	public Point2D norm() {
		return norm(1);
	}
	
	public double cross(Point2D p) {
		return x * p.y - y * p.x;
	}
	
	public double dot(Point2D p) {
		return x * p.x + y * p.y;
	}
	
	@Override
	public boolean equals(Object obj) {
		if (!(obj instanceof Point2D))
			return false;
		Point2D p = (Point2D)obj;
		return dist2(p) < 1e-6;
	}
	
	@Override
	public String toString() {
		return "(" + x + ", " + y + ")";
	}	
}
