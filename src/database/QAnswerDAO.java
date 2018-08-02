package database;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;

import model.Answers;
import model.Dataholder;
import model.Hash;
import model.Main;
import model.QAnswers;
import model.Questions;


public class QAnswerDAO extends BaseDAO {

	public QAnswerDAO() {

	}

	public static ArrayList<QAnswers> getQAnswers(int i) {
		ArrayList<QAnswers> list = null;

		PreparedStatement pst = null;
		ResultSet rs = null;

		String sql = "SELECT * FROM QAnswers where qId =?";
		try {
			Connection c = getCon();
			if (c == null || c.isClosed()) {
				// afhandelen zoals je zelf wilt
				throw new IllegalStateException("Connection onverwacht beeindigd");
			}
			pst = getCon().prepareStatement(sql);
			pst.setInt(1, i);
			rs =pst.executeQuery();
			list = new ArrayList<QAnswers>();

			while (rs.next()) {
				QAnswers q = new QAnswers(rs.getInt(1),rs.getInt(2),rs.getString(3));
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

	@SuppressWarnings("resource")
	public static void submitAnswer(QAnswers a){
		PreparedStatement st = null;
		ResultSet rs = null; 
		try {
			Connection c = getCon();
			if (c == null || c.isClosed()) {
				// afhandelen zoals je zelf wilt
				throw new IllegalStateException("Connection onverwacht beeindigd");
			}
			String query = "select * from QAnswers where qId = ? and uId = ?";
			st = getCon().prepareStatement(query);
			st.setInt(1, a.getqId());
			st.setString(2, a.getuId());
			rs = st.executeQuery();

			if (!(rs.next())) {
				String query2 = "INSERT INTO QAnswers (qId, aId, uId) VALUES (?, ?, ?)";
				st = getCon().prepareStatement(query2);
				st.setInt(1, a.getqId());
				st.setInt(2, a.getaId());
				st.setString(3, a.getuId());
				st.executeUpdate();
			}else{
				String query3 = "UPDATE QAnswers SET aId=? WHERE qId = ? and uId = ?";
				st = getCon().prepareStatement(query3);
				st.setInt(1, a.getaId());
				st.setInt(2, a.getqId());
				st.setString(3, a.getuId());
				st.executeUpdate();
			}
		} catch (SQLException e) {
			System.out.println(e.getMessage());
			throw new RuntimeException("error.unexpected");
		} finally{
			try {
				if (st != null)
					st.close();
				if (rs != null)
					rs.close();
			} catch (SQLException e) {
				System.out.println(e.getMessage());
				throw new RuntimeException("error.unexpected");
			}
		}

	}

	public static ArrayList<Dataholder> getStats(int i) {
		ArrayList<Dataholder> list = null;
		PreparedStatement pst = null;
		ResultSet rs = null;

		String sql = "SELECT aId,count(uId) FROM QAnswers where qId =? group by 1";
		try {
			Connection c = getCon();
			if (c == null || c.isClosed()) {
				// afhandelen zoals je zelf wilt
				throw new IllegalStateException("Connection onverwacht beeindigd");
			}
			pst = getCon().prepareStatement(sql);
			pst.setInt(1, i);
			rs =pst.executeQuery();
			list = new ArrayList<Dataholder>();

			while (rs.next()) {
				Dataholder q = new Dataholder(rs.getString(1),rs.getInt(2));
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