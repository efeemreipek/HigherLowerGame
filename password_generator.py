import string
import random

lowercase_letters = string.ascii_lowercase
upppercase_letters = string.ascii_uppercase
numbers = string.digits
symbols = string.punctuation

user_lowercase = int(input("How many lowercase letters do you want in your password?: "))
user_uppercase = int(input("How many uppercase letters do you want in your password?: "))
user_numbers = int(input("How many numbers do you want in your password?: "))
user_symbols = int(input("How many symbols do you want in your password?: "))

password_length = user_lowercase + user_uppercase + user_numbers + user_symbols

password = []

while len(password) != password_length:
    for i in range(user_lowercase):
        password.append(random.choice(lowercase_letters))
    for i in range(user_uppercase):
        password.append(random.choice(upppercase_letters))
    for i in range(user_numbers):
        password.append(random.choice(numbers))
    for i in range(user_symbols):
        password.append(random.choice(symbols))

shuffled_password = random.sample(password, len(password))

print("".join(shuffled_password))