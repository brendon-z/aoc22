import java.io.File;
import java.util.Scanner;

public class four {
    public static void main(String args[]) throws Exception {
        File input = new File("input.txt");
        Scanner scanner = new Scanner(input);
 
        int count = 0;
        while (scanner.hasNextLine()) {
            String pair = scanner.nextLine();
            if (contains(pair)) count++;
        }

        System.out.println("Overlaps: " + count);
        scanner.close();
    }

    public static boolean contains(String pair) {
        String first = pair.split(",")[0];
        String second = pair.split(",")[1];
        int first1st = Integer.parseInt(first.split("-")[0]);
        int first2nd = Integer.parseInt(first.split("-")[1]);
        int second1st = Integer.parseInt(second.split("-")[0]);
        int second2nd = Integer.parseInt(second.split("-")[1]);

        if ((first1st <= second1st && first2nd >= second2nd) || (second1st <= first1st && second2nd >= first2nd)) {
            return true;
        }
        return false;
    }
}
