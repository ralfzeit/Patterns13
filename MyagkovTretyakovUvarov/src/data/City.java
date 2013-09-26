package data;

import geom.Point2D;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;

public class City {
	
	private String name;
	private ArrayList<BusStop> busStops;
	private ArrayList<BusRoute> busRoutes;
	private CityMap map;
	
	private Map<Integer, BusStop> busStopById = new HashMap<>();
	private int maxId;

	public City(String name, CityMap cityMap) {
		this.name = name;
		busStops = new ArrayList<>();
		busRoutes = new ArrayList<>();
		this.map = cityMap;
	}
	
	public boolean removeBusStop(BusStop stop) {
		if (stop.getCntRoutes() != 0)
			return false;
		for (int i = 0; i < busStops.size(); i++)
			if (busStops.get(i).getId() == stop.getId())
				busStops.remove(i);
		busStopById.remove(stop.getId());
		return true;
	}
	
	public BusStop getBusStopById(int id) {
		return busStopById.get(id);
	}
	
	public boolean canAddRoute(String name) {
		if (name == null)
			return false;
		for (BusRoute route : busRoutes)
			if (name.equals(route.getName()))
				return false;
		return true;
	}
	
	public void addRoute(BusRoute route) {
		if (!canAddRoute(route.getName()))
			throw new IllegalArgumentException("Route " + route + " alredy exists.");
		busRoutes.add(route);
	}
	
	public ArrayList<BusRoute> getBusRoutes() {
		return busRoutes;
	}

	public boolean canAddStop(BusStop stop) {
		if (stop == null)
			return false;
		for (BusStop s : busStops)
			if (s.equals(stop))
				return false;
		return true;
	}

	public void addBusStop(BusStop stop) {
		if (!canAddStop(stop))
			throw new IllegalArgumentException("Stop " + stop + " alredy exists.");
		if (busStopById.get(stop.getId()) != null)
			throw new IllegalArgumentException("ID " + stop.getId() + " alredy exists.");
		maxId = Math.max(maxId, stop.getId());
		busStops.add(stop);
		busStopById.put(stop.getId(), stop);
	}
	
	public void removeBusRoute(BusRoute route) {
		for (int stopId : route.stops)
			busStopById.get(stopId).decCntRoutes();
		busRoutes.remove(route);
	}

	public void addBusStop(String name, Point2D position) {
		BusStop stop = new BusStop(name, position, ++maxId);
		if (!canAddStop(stop))
			throw new IllegalArgumentException("Stop " + stop + " alredy exists.");
		busStops.add(stop);
		busStopById.put(stop.getId(), stop);
	}
	
	public ArrayList<BusRoute> getBusRotuesByStop(BusStop stop) {
		ArrayList<BusRoute> ret = new ArrayList<>();

		
		for (BusRoute route : busRoutes) 
			if (route.containsBusStop(stop))
				ret.add(route);
		
		return ret;
	}
	
	public CityMap getMap() {
		return  map;
	}
	
	public String getName() {
		return name;
	}
	
	public ArrayList<BusStop> getBusStops() {
		return busStops;
	}
	
}
