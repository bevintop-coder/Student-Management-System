import java.util.ArrayList;
import java.util.Scanner;

class Account {
    int accNo;
    String name;
    double balance;

    Account(int accNo, String name, double balance) {
        this.accNo = accNo;
        this.name = name;
        this.balance = balance;
    }

    void display() {
        System.out.println("Account No: " + accNo);
        System.out.println("Name: " + name);
        System.out.println("Balance: " + balance);
        System.out.println("----------------------");
    }
}

public class BankingSystem {

    static ArrayList<Account> accounts = new ArrayList<>();
    static Scanner sc = new Scanner(System.in);

    static void createAccount() {
        System.out.print("Enter Account Number: ");
        int accNo = sc.nextInt();
        sc.nextLine();

        System.out.print("Enter Name: ");
        String name = sc.nextLine();

        System.out.print("Enter Initial Deposit: ");
        double balance = sc.nextDouble();

        accounts.add(new Account(accNo, name, balance));
        System.out.println("Account created successfully!\n");
    }

    static Account findAccount(int accNo) {
        for (Account a : accounts) {
            if (a.accNo == accNo) {
                return a;
            }
        }
        return null;
    }

    static void deposit() {
        System.out.print("Enter Account No: ");
        int accNo = sc.nextInt();

        Account a = findAccount(accNo);

        if (a != null) {
            System.out.print("Enter Amount: ");
            double amt = sc.nextDouble();
            a.balance += amt;
            System.out.println("Deposit successful!\n");
        } else {
            System.out.println("Account not found!\n");
        }
    }

    static void withdraw() {
        System.out.print("Enter Account No: ");
        int accNo = sc.nextInt();

        Account a = findAccount(accNo);

        if (a != null) {
            System.out.print("Enter Amount: ");
            double amt = sc.nextDouble();

            if (amt <= a.balance) {
                a.balance -= amt;
                System.out.println("Withdrawal successful!\n");
            } else {
                System.out.println("Insufficient balance!\n");
            }
        } else {
            System.out.println("Account not found!\n");
        }
    }

    static void checkBalance() {
        System.out.print("Enter Account No: ");
        int accNo = sc.nextInt();

        Account a = findAccount(accNo);

        if (a != null) {
            System.out.println("Balance: " + a.balance + "\n");
        } else {
            System.out.println("Account not found!\n");
        }
    }

    static void showAllAccounts() {
        if (accounts.isEmpty()) {
            System.out.println("No accounts found!\n");
            return;
        }

        for (Account a : accounts) {
            a.display();
        }
    }

    public static void main(String[] args) {

        while (true) {
            System.out.println("===== BANKING SYSTEM =====");
            System.out.println("1. Create Account");
            System.out.println("2. Deposit");
            System.out.println("3. Withdraw");
            System.out.println("4. Check Balance");
            System.out.println("5. Show All Accounts");
            System.out.println("6. Exit");
            System.out.print("Enter choice: ");

            int choice = sc.nextInt();

            switch (choice) {
                case 1 -> createAccount();
                case 2 -> deposit();
                case 3 -> withdraw();
                case 4 -> checkBalance();
                case 5 -> showAllAccounts();
                case 6 -> System.exit(0);
                default -> System.out.println("Invalid choice!\n");
            }
        }
    }
}