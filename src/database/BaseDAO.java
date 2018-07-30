package database;

import java.sql.Connection;
import java.sql.SQLException;

public class BaseDAO {

	private static Connection con;

	public BaseDAO() {
		
	}

	public static Connection getCon() {
		try {
			con = DatabaseSingleton.getDatabaseSingleton().getConnection(true);
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		return con;
	}

	public void setCon(Connection con) {
		BaseDAO.con = con;
	}

}
