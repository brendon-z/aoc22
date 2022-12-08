import java.io.File;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.Arrays;
import java.util.Scanner;

public class eight {
    public static void main(String args[]) throws Exception {
        File input = new File("input.txt");
        Scanner scanner = new Scanner(input);
        int rowCount = Math.toIntExact(Files.lines(Paths.get("input.txt")).count());
        int colCount = scanner.nextLine().length();
        scanner.close();

        scanner = new Scanner(input);

        Tree[][] trees = new Tree[rowCount][colCount];

        for (int i = 0; i < rowCount; i++) {
            String line = scanner.nextLine();
            for (int j = 0; j < colCount; j++) {
                trees[i][j] = new Tree(Integer.parseInt(Character.toString(line.charAt(j))));
                if (i == 0 || i == rowCount - 1 || j == 0 || j == rowCount - 1) {
                    trees[i][j].setVisible(true);
                }
            }
        }
        scanner.close();

        setVisibility(trees, rowCount, colCount);
        int visible = 0;
        int score = 0;
        for (int i = 0; i < rowCount; i++) {
            for (int j = 0; j < colCount; j++) {
                if (trees[i][j].isVisible()) {
                    visible++;
                }
                if (trees[i][j].getScenicScore() > score) {
                    score = trees[i][j].getScenicScore();
                }
            }
        }

        System.out.println("Visible: " + visible);
        System.out.println("Highest scenic score: " + score);
    }

    private static void setVisibility(Tree[][] trees, int rowCount, int colCount) {
        for (int i = 1; i < rowCount - 1; i++) {
            for (int j = 1; j < colCount - 1; j++) {
                int colToGet = j;
                trees[i][j].setVisible(visibleSide1(trees[i], j) || visibleSide2(trees[i], j)
                        || visibleSide1(Arrays.stream(trees).map(x -> x[colToGet]).toArray(Tree[]::new), i)
                        || visibleSide2(Arrays.stream(trees).map(x -> x[colToGet]).toArray(Tree[]::new), i));
                trees[i][j].setScenicScore(calculateRowScore(trees[i], j) *
                        calculateRowScore(Arrays.stream(trees).map(x -> x[colToGet]).toArray(Tree[]::new), i));
            }

        }
    }

    private static boolean visibleSide1(Tree[] row, int index) {
        for (int i = index + 1; i < row.length; i++) {
            if (row[i].getHeight() >= row[index].getHeight()) {
                return false;
            }
        }
        return true;
    }

    private static boolean visibleSide2(Tree[] row, int index) {
        for (int i = index - 1; i >= 0; i--) {
            if (row[i].getHeight() >= row[index].getHeight()) {
                return false;
            }
        }
        return true;
    }

    private static int calculateRowScore(Tree[] row, int index) {
        int rowScore = 0;
        for (int i = index + 1; i < row.length; i++) {
            rowScore++;
            if (row[i].getHeight() >= row[index].getHeight()) {
                break;
            }
        }

        int counter = 0;
        for (int i = index - 1; i >= 0; i--) {
            counter++;
            if (row[i].getHeight() >= row[index].getHeight()) {
                break;
            }
        }

        return rowScore * counter;
    }
}