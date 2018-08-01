package database;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;

import model.Questions;


public class QuestionDAO extends BaseDAO {

	public QuestionDAO() {

	}

	public static ArrayList<Questions> getAll() {
		ArrayList<Questions> list = null;

		PreparedStatement pst = null;
		ResultSet rs = null;

		String sql = "SELECT * FROM Questions";
		try {
			Connection c = getCon();
			if (c == null || c.isClosed()) {
				// afhandelen zoals je zelf wilt
				throw new IllegalStateException("Connection onverwacht beeindigd");
			}
			pst = getCon().prepareStatement(sql);
			rs =pst.executeQuery();
			list = new ArrayList<Questions>();

			while (rs.next()) {
				Questions q = new Questions(rs.getInt(1),rs.getString(2),rs.getString(3),rs.getString(4));
				list.add(q);
			}

			return list;
		} catch (SQLException e) {
			System.out.println(e.getMessage());
			throw new RuntimeException(e.getMessage());
		} finally {
			try {
				if (pst != null)
					pst.close();
				if (rs != null)
					rs.close();
			} catch (SQLException e) {
				System.out.println(e.getMessage());
				throw new RuntimeException("error.unexpected");
			}
		}
	}

}