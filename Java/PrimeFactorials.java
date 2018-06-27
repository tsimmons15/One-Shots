package prime_factorials;

import java.util.ArrayList;
import java.util.Collections;

public class PrimeFactorials {

    public static void main(String[] args) {
        int m = 0;
        ArrayList<Integer> factors = new ArrayList<Integer>();
        
        m = 90;
        
        primeFactorials(new Integer(m), new Integer(m/2), factors);
        
        int n = findOddPowers(factors);
        
        System.out.println("With an m = " + m + ", the perfect square is: " + (m * n));
    }
    
    public static void primeFactorials(Integer m, Integer i, ArrayList<Integer> factors) {
        if (m <= 1) {
        	return;
        }
        else {
        	if (m % i == 0) {
        		if (isPrime(i)) {
        			factors.add(i);
        		}
        		else {
        			primeFactorials(new Integer(i), new Integer(i/2), factors);
        		}
        		m /= i;
        		i = m + 1;
        	}
        	
        	primeFactorials(m, i-1, factors);
        }
    }
    
    public static boolean isPrime(int i) {
        boolean isPrimeNumber = true;
        
        if (i <= 1)
        	return false;
        
        for (int j = 2; j <= i/2; j++) {
            if (i % j == 0) {
                isPrimeNumber = false;
                break;
            }
        }
        
        return isPrimeNumber;
    }
    
    public static int findOddPowers(ArrayList<Integer> factors) {
    	int n = 1;
    	int count = 0;
    	int minFactor = Collections.min(factors);
    	int maxFactor = Collections.max(factors);
    	int factorsLength = factors.size();
    	
    	for (int i = minFactor; i <= maxFactor; i++) {
    		count = 0;
    		for(int j = 0; j < factorsLength; j++) {
    			if (factors.get(j) == i) {
    				count++;
    			}
    		}
    		
    		if (count % 2 == 1) {
    			n *= i;
    		}
    	}
    	
    	return n;
    }
}

