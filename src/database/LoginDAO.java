package database;

import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

import model.Hash;
import model.Users;

public class LoginDAO extends BaseDAO {

	public static boolean loginUser(Users u) {
		Statement st = null;
		try {
			Connection c = getCon();
			if (c == null || c.isClosed()) {
				// afhandelen zoals je zelf wilt
				throw new IllegalStateException("Connection onverwacht beeindigd");
			}
			st = getCon().createStatement();
			String query = "select * from Users where email = '" + u.getEmail() + "' and psw = '" + Hash.getHash(u.getPsw().getBytes())+ "'";
			ResultSet rs = st
					.executeQuery(query);

			while (rs.next()) {
				return true;
			}
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

		return false;
	}

}
