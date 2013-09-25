package utils;

import geom.Line2D;
import geom.Point2D;

import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.io.PrintWriter;
import java.util.ArrayList;

import data.BusRoute;
import data.BusStop;
import data.City;
import data.CityMap;
import data.Street;

public class SimpleSaver implements CityReader, CityWriter {
	
	private String fileName;
	
	public SimpleSaver(String fileName) {
		this.fileName = fileName;
	}
	
	
	@Override
	public void writeCity(City city) throws IOException {
		PrintWriter out = new PrintWriter(new OutputStreamWriter(new FileOutputStream(fileName), "UTF8"));
		
		out.println(city.getName());
		CityMap map = city.getMap();
		out.println(map.getWidth());
		out.println(map.getHeight());
		
		{//print map
			ArrayList<Street> streets = map.getStreets();
			
			out.println(streets.size());
			
			for (Street s : streets) {//street
				out.println(s.getName());

				Line2D seg = s.getSegment();
				out.println(seg.getFrom().getX());
				out.println(seg.getFrom().getY());
				out.println(seg.getTo().getX());
				out.println(seg.getTo().getY());
			}
		}
		
		{//print busStops
			ArrayList<BusStop> busStops = city.getBusStops(); 
		
			out.println(busStops.size());
			
			for (BusStop stop : busStops) { //bus stop
				out.println(stop.getName());
				out.println(stop.getId());
				out.println(stop.getX());
				out.println(stop.getY());
			}
		}
		
		{//print busRoutes
			ArrayList<BusRoute> busRoutes = city.getBusRoutes();
			out.println(busRoutes.size());
			
			for (BusRoute route : busRoutes) {
				out.println(route.getName());
				out.println(route.getCountBusStop());
				for (int i = 0; i < route.getCountBusStop(); i++)
					out.println(route.getBusStopId(i));
				
				out.println(route.getPath().size());
				for (Point2D p : route.getPath()) {
					out.println(p.getX());
					out.println(p.getY());
				}
			}
			
		}
		
		out.close();
	}

	@Override
	public City readCity() throws IOException {
		
		FastReader in = new FastReader(new InputStreamReader(new FileInputStream(fileName), "UTF8"));
		String cityName = in.nextLine();
		
		CityMap map = new CityMap(in.nextDouble(), in.nextDouble());
		
		{// readMap
			int cntStreet = in.nextInt();
			for (int i = 0; i < cntStreet; i++) {
				String name = in.nextLine();
				Point2D from = new Point2D(in.nextDouble(), in.nextDouble());
				Point2D to = new Point2D(in.nextDouble(), in.nextDouble());
				map.addStreet(new Street(name, from, to));
			}
		}
		
		City city = new City(cityName, map);
		
		{//busStop
			int cntStops = in.nextInt();
			for (int i = 0; i < cntStops; i++) {
				String name = in.nextLine();
				int id = in.nextInt();
				Point2D pos = new Point2D(in.nextDouble(), in.nextDouble());
				city.addBusStop(new BusStop(name, pos, id));
			}
		}
		
		{//busRoute
			int cntRoutes = in.nextInt();
			for (int i = 0; i < cntRoutes; i++) {
				BusRoute route = new BusRoute(in.nextLine(), city);
				
				for (int j = in.nextInt(); j --> 0;) {
					int id;
					route.addBusStop(id = in.nextInt());
					city.getBusStopById(id).incCntRoutes();
				}
				
				for (int j = in.nextInt(); j --> 0;)
					route.addPath(new Point2D(in.nextDouble(), in.nextDouble()));
				city.addRoute(route);
			}
		}
		map.normalaize();
		
		in.close();
		return city;
	}

}
