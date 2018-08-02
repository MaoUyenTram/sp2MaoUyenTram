package model;

import java.security.MessageDigest;
import javax.xml.bind.DatatypeConverter;

public class Hash  implements java.io.Serializable{
	/**
	 * 
	 */
	private static final long serialVersionUID = 392332081873857757L;

	public static String getHash(byte[] inputBytes) {
		String hashValue = "";
		try {
			MessageDigest messageDigest = MessageDigest.getInstance("SHA-512");
			messageDigest.update(inputBytes);
			byte[] digestedBytes = messageDigest.digest();
			hashValue = DatatypeConverter.printHexBinary(digestedBytes).toLowerCase();
		} catch (Exception e) {
			e.printStackTrace();
		}
		System.out.println(hashValue);
		return hashValue;
	}
}
