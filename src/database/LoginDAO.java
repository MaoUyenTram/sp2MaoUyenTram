package database;

import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.sql.PreparedStatement;

import model.Hash;
import model.Users;

public class LoginDAO extends BaseDAO {

	public static boolean loginUser(Users u) {
		final Users user;
		PreparedStatement st = null;
		ResultSet rs = null; 
		try {
			Connection c = getCon();
			if (c == null || c.isClosed()) {
				// afhandelen zoals je zelf wilt
				throw new IllegalStateException("Connection onverwacht beeindigd");
			}
			
			String query = "select * from Users where email = ? and psw = ?";
			st = getCon().prepareStatement(query);
			st.setString(1, u.getEmail());
			st.setString(2, Hash.getHash(u.getPsw().getBytes()));
			rs = st.executeQuery();

			while (rs.next()) {
				 user = new Users(rs.getString(1),rs.getString(2),rs.getString(3),rs.getBoolean(4));
				
				return true;
			}
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

		return false;
	}

}
