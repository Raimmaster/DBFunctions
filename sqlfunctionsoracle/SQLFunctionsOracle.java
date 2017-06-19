package sqlfunctionsoracle;

import java.io.IOException;
import java.net.InetSocketAddress;
import java.net.Socket;

public class SQLFunctionsOracle {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        System.out.println(trim("aaahola a todas las personasaaa", 'a'));
        System.out.printf("Fahrenheit %f to C: %f %n", 50.50, F2C(50.50));
        System.out.printf("Celcius %f to F: %f %n", 32.50, C2F(32.50));
        System.out.printf("Factorial of %d = %d %n", 6, Factorial(6));
        System.out.printf("Factorial of %d = %d %n", 9, Factorial(9));
        String bina = "1100";
        System.out.printf("Bin %s to dec %d%n", bina, BIN2DEC(bina));
        int num = 99;
        System.out.printf("Dec %d to bin %s%n", num, DEC2BIN(num));
        System.out.printf("Dec %d to hex %s%n", num, DEC2HEX(num));
        System.out.println("Repeated str: " + REPEAT("hola", 5));
        String str1 = "hola";
        String str2 = "holasss";
        System.out.printf("Compare %s with %s: %s %n", str1, str2, COMPARE(str1, str2));
        System.out.printf("PMT: %f%n", PMT(0.05, 10, 5000));
        System.out.printf("Ping: %d%n", PING("google.com"));
    }

    private static String trim(String str, char replaceChar) {
        String regex = "\\A" + replaceChar + "*";
        String returnVal = str.replaceAll(regex, "");
        regex = replaceChar + "*\\z" ;
        return returnVal.replaceAll(regex, "");
    }
    
    public static double F2C(double fahrenheitTemperature)
    {
        return (fahrenheitTemperature - 32) * 5/9;
    }  
   
    public static double C2F(double celciusTemperature)
    {
        return (celciusTemperature * 9/5) + 32;
    }

    public static int Factorial(int numToFactorial)
    {
        int result = 1;
        for(int i = 1; i <= numToFactorial; ++i )
        {
            result *= i;
        }
        
        return result;
    }

    public static int BIN2DEC(String binaryNumber)
    {   
        return Integer.parseInt(binaryNumber, 2);
    }
    
    public static String DEC2BIN(int decNumber)
    {
        return Integer.toBinaryString(decNumber);
    }
    
    public static int HEX2DEC(String hexNumber)
    {
        return Integer.parseInt(hexNumber, 16);
    }
    
    public static String DEC2HEX(int number)
    {        
        return Integer.toHexString(number);
    }
    
    public static String REPEAT(String str, int toRepeat)
    {
        String strR = "";
        for(int i = 0; i < toRepeat; ++i)
        {
            strR += str;
        }
        
        return strR;
    }
    
    public static String COMPARE(String str1, String str2)
    {
        int result = str1.compareTo(str2);
        if(result > 0)
            return "1";
        else if (result < 0)
            return "-1";
        return "" + result;
    }
    
    public static double PMT(double tasa, int numPeriodos, double prestamo){
        return (prestamo*tasa) / (1 - Math.pow((1 + tasa), (-numPeriodos)));
    }
    
    public static int PING(String ipName)
    {
        try {
            Socket sock = new Socket();
            sock.connect(new InetSocketAddress(ipName, 80), 5000);
            sock.close();
            return 1;
        }
        catch(IOException e) {
            return 0;
        }
    }
}
