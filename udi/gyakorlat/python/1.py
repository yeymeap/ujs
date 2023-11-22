age = int(input("Your age: "))
if(age < 18):
    print("You are not old enough to enter!")
elif(age >= 18):
    if(age >= 18 and age < 96):
        print("Welcome!")
    else:
        print("I've never seen anyone above age 95, but welcome anyway!")
