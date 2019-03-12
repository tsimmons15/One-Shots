import random

target = float(input("The target?"))
max_value = float(input("The max value possible?"))
epsilon = 0.001
count = int(input("How many items in list?"))
numbers = [0] * (count if count > 0 else 5)

def findClosestDifference(numbers, target, difference):
    # Base case:
    # Since the difference will always be positive, stop when the differene
    #  is between [0, epsilon], where epsilon is an arbitrary precision
    if difference <= epsilon:
        # Now that we have our 'final' list, convert them to the ints used
        # to calculate the difference.
        return [int(i) for i in numbers]
    
    theSum = sum(int(i) for i in numbers)
    #Calculate the absolute value of the average of our current list and our 
    # target; used to determine our steps.
    newDifference = abs(theSum / len(numbers) - target)
    # Since we're going to be messing with the difference to calculate our steps
    # save it in a throw away temp
    tempDifference = newDifference
    
    #Step up each of our numbers
    for i in range(len(numbers)):
        # Calculate the random step percentage
        # if we're at the end of our list
        if i == (len(numbers)-1):
            # just take the rest of the difference
            #This has a few effects
            # 1) Without this, the first few items tend to just become really
            #   big, really fast. This can help give more to the latter indices
            # 2) Also, it can help avoid needing to go through more iterations
            #     since it's not guaranteed our randomly generated percentages
            #     will 'equal' 100%.
            rand = 1
        else:
            # Otherwise generate our random step amount
            rand = random.random()
        
        # Calculate our delta
        delta = tempDifference * rand
        
        # Delta is used to determine if this amount would take us over the max
        # value allowed for the list
        if (numbers[i] + delta > max_value):
            # If it would, just continue.
            continue
        
        #If the delta wouldn't take us above max_value, increase index by delta
        numbers[i] = numbers[i] + delta
        # Remove delta from the difference
        tempDifference = tempDifference - delta
        
        #If tempDifference is equal to 0 (say if our rand is 1), don't bother
        #  accessing the rest of the list
        if tempDifference == 0:
            break
    
    #Continue finding next steps, returning the final product once finished
    return findClosestDifference(numbers, target, newDifference)

def main():
    random.seed()
    #Initialize the difference
    difference = abs(sum(int(i) for i in numbers)/len(numbers) - target)
    print('Original difference:', difference)
    final = findClosestDifference(numbers, target, difference)
    print('The final value:', final)
    difference = abs(sum(int(i) for i in numbers)/len(numbers) - target)
    print('The final difference:', difference)
    
if __name__ == "__main__":
    main()
