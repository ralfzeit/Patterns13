package utils;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.StringTokenizer;

public class FastReader {

	private StringTokenizer st = new StringTokenizer("");
	private BufferedReader in;

	public FastReader(InputStreamReader input) {
		in = new BufferedReader(input);
	}

	public void close() throws IOException {
		in.close();
	}
	
	public String nextToken() throws IOException {
		while (!st.hasMoreTokens())
			st = new StringTokenizer(in.readLine());
		return st.nextToken();
	}

	public int nextInt() throws IOException {
		return Integer.parseInt(nextToken());
	}

	public long nextLong() throws IOException {
		return Long.parseLong(nextToken());
	}

	public double nextDouble() throws IOException {
		return Double.parseDouble(nextToken());
	}

	public String nextLine() throws IOException {
		st = new StringTokenizer("");
		return in.readLine();
	}
	
}
