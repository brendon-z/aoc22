// Tree data class
public class Tree {
    private int height;
    private boolean visible;
    private int scenicScore;

    public Tree(int height) {
        this.height = height;
        this.visible = false;
        this.scenicScore = 0;
    }

    public int getHeight() {
        return height;
    }

    public boolean isVisible() {
        return visible;
    }

    public void setVisible(boolean visible) {
        this.visible = visible;
    }

    public void setScenicScore(int score) {
        this.scenicScore = score;
    }

    public int getScenicScore() {
        return scenicScore;
    }
}
