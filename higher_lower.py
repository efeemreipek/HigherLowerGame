import random as rnd

number = rnd.randint(1,100)
guess = int(input("Guess the number between 1-100: "))

count = 0
while number != guess:
    if number < guess:
        count += 1
        guess = int(input("Lower. Try again: "))
    elif number > guess:
        count += 1
        guess = int(input("Higher. Try again: "))
        
if number == guess:
    print("Congratulations. You guessed in your {}. try ".format(count+1))

