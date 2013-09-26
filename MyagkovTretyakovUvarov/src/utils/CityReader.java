package utils;

import java.io.IOException;

import data.City;

public interface CityReader {
	
	public City readCity() throws IOException;
	
}
