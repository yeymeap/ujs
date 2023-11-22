import random
check = int(input("play with other player - 0\nplay with computer - 1\n"))
player1points = 0
player2points = 0
computerPoints = 0

if(check == 1):
    while True:
        status = int(input("add num y - 1, exit - 0\n"))
        if(status == 1):
            randomnumber = random.randint(1, 10)
            player1points += randomnumber
            comprandom = random.randint(1,10)
            computerPoints += comprandom
        elif(status == 0):
            break
        if(player1points >= 100 or computerPoints >= 100):
            break
        print("your points:", player1points)
        print("computer point:", computerPoints)
        
if(check == 1):  
    if(player1points > 100 or computerPoints > player1points and computerPoints <= 100):
        print('you lost, points:', player1points, '\ncomputer points:', computerPoints)
    else:
        print('you won, points:', player1points, '\ncomputer points:', computerPoints)
        
elif(check == 0):
    while True:
        input1 = int(input("player 1, add num y - 1, stop - 0\n"))
        if(input1 == 1):
            randomnumber = random.randint(1, 10)
            player1points += randomnumber
        input2 = int(input("player 2, add num y - 1, stop - 0\n"))
        if(input2 == 1):
            randomnumber = random.randint(1, 10)
            player2points += randomnumber
        print("player 1 points:", player1points)
        print("player 2 points:", player2points)
        if(player1points >= 100 or player2points >= 100):
            break
        
    if(player1points > 100 and player2points > 100):
        if(player1points < player2points):
            print('player 1 wins!\nplayer 1 points:', player1points,'\nplayer 2 points:', player2points)
        elif(player1points > player2points):
            print('player 2 wins!\nplayer 1 points:', player1points,'\nplayer 2 points:', player2points)
            
    elif(player1points > 100):
        print('player 2 wins!\nplayer 1 points:', player1points,'\nplayer 2 points:', player2points)
        
    elif(player2points > 100):
        print('player 1 wins!\nplayer 1 points:', player1points,'\nplayer 2 points:', player2points)
    
    else:
        if player1points > player2points:
            print('player 1 wins!\nplayer 1 points:', player1points,'\nplayer 2 points:', player2points)
        elif player2points > player1points:
            print('player 2 wins!\nplayer 1 points:', player1points,'\nplayer 2 points:', player2points)