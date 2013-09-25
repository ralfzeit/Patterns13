package data;

import geom.Point2D;

import java.util.ArrayList;
import java.util.Collections;

import utils.Pair;
import utils.Time;

public class BusRoute {
	
	private static int lastId = 0;
	private final static double velocity = 40.0;
	
	private String name;
	private final int id;
	public ArrayList<Integer> stops;
	public ArrayList<Point2D> path;
	private final City city;
	
	private ArrayList<Time> forward;
	private ArrayList<Time> backward;
	
	public BusRoute(String name, City city) {
		id = ++lastId;
		this.name = name;
		stops = new ArrayList<>();
		path = new ArrayList<>();
		this.city = city;
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
	
	public int getBusStopId(int index) {
		if (0 > index || index >= stops.size())
			return -1;
		return stops.get(index);
	}
	
	public int getCountBusStop() {
		return stops.size();
	}
	
	public ArrayList<Point2D> getPath() {
		return new ArrayList<>(path);
	}
	
	public void addBusStop(int id) {
		stops.add(id);
		updateTimetable();
	}

	public void addPath(Point2D p) {
		path.add(p);
		updateTimetable();
	}
	
	public boolean isLastStop(BusStop stop) {
		if (stops.isEmpty())
			return false;
		if (stop == null)
			return false;
		return stop.equals(stops.get(0)) || stop.equals(stops.get(stops.size() - 1)); 
	}
	
	public boolean containsBusStop(BusStop stop) {
		return stops.contains(stop.getId());
	}

	public void updateTimetable() {
		forward = updateTimetable(stops, path);
		ArrayList<Integer> revStop = new ArrayList<>(stops);
		Collections.reverse(revStop);
		ArrayList<Point2D> revPath = new ArrayList<>(path);
		Collections.reverse(revPath);
		
		backward = updateTimetable(revStop, revPath);
		Collections.reverse(backward);
	}
	
	public ArrayList<Pair<BusStop, Pair<Time, Time>>> getPathList() {
		ArrayList<Pair<BusStop, Pair<Time, Time>>> ret = new ArrayList<>(stops.size());
		for (int i = 0; i < stops.size(); i++) {
			BusStop stop = city.getBusStopById(stops.get(i));
			Time f = forward.get(i);
			Time b = backward.get(i);
			ret.add(new Pair<>(stop, new Pair<>(f, b)));
		}
		
		return ret;
	}
	
	private ArrayList<Time> updateTimetable(ArrayList<Integer> stops, ArrayList<Point2D> path) {
		ArrayList<Time> times = new ArrayList<>();
		int pos = 0;
		final double scaleX = city.getMap().getWidth();
		final double scaleY = city.getMap().getHeight();
		Time curTime = null;
		Point2D prevPoint = null;
		for (Point2D p : path) {
			if (pos == stops.size())
				break;
			if (curTime != null) {
				if (prevPoint != null) {
					double tm = prevPoint.dist(p, scaleX, scaleY) / velocity;
					curTime = curTime.add(new Time(tm));
				}
			}
			prevPoint = p;
			if (!city.getBusStopById(stops.get(pos)).getPosition().equals(p))
				continue;
			pos++;
			if (curTime == null)
				curTime = new Time(0.0);
			times.add(curTime);
		}
		return times;
	}
	
	
	@Override
	public boolean equals(Object obj) {
		if (!(obj instanceof BusRoute))
			return false;
		BusRoute route = (BusRoute) obj;
		return id == route.id;
	}
	
	@Override
	public String toString() {
		return name;
	}

}
