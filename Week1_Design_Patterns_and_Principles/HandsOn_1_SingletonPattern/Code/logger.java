public class logger {

    // Step 1: Create a private static instance of the same class
    private static logger singleInstance;

    // Step 2: Make the constructor private so it can't be instantiated from outside
    private logger() {
        System.out.println("Logger Initialized");
    }

    // Step 3: Provide a public static method to get the instance
    public static logger getInstance() {
        if (singleInstance == null) {
            singleInstance = new logger();
        }
        return singleInstance;
    }

    // Example method to simulate logging
    public void log(String message) {
        System.out.println("[LOG]: " + message);
    }
}
