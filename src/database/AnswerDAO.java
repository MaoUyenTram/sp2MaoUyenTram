package database;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;

import model.Answers;
import model.Questions;


public class AnswerDAO extends BaseDAO {

	public AnswerDAO() {

	}

	public static ArrayList<Answers> getAnswers(int i) {
		ArrayList<Answers> list = null;

		PreparedStatement pst = null;
		ResultSet rs = null;

		String sql = "SELECT * FROM Answers where qId =?";
		try {
			Connection c = getCon();
			if (c == null || c.isClosed()) {
				// afhandelen zoals je zelf wilt
				throw new IllegalStateException("Connection onverwacht beeindigd");
			}
			pst = getCon().prepareStatement(sql);
			pst.setInt(1, i);
			rs =pst.executeQuery();
			list = new ArrayList<Answers>();

			while (rs.next()) {
				Answers q = new Answers(rs.getInt(1),rs.getInt(2),rs.getString(3));
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