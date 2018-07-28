package database;

import java.sql.Connection;
import java.sql.SQLException;

public class BaseDAO {

	private static Connection con;
	
	public BaseDAO()
	{
		try {
			con = DatabaseSingleton.getDatabaseSingleton().getConnection(true);
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}

	public static Connection getCon() {
		return con;
	}

	public void setCon(Connection con) {
		this.con = con;
	}
	
	
	
	
}
