import turtle
import random

turtle.bgcolor("#9BD1FF")

t1 = turtle.Turtle()
t1.penup()
t1.color("red")
t1.shape("turtle")
t1.goto(-300,-275)
t1.left(90)
t1.pendown()

t2 = turtle.Turtle()
t2.penup()
t2.color("orange")
t2.shape("turtle")
t2.goto(-180,-275)
t2.left(90)
t2.pendown()

t3 = turtle.Turtle()
t3.penup()
t3.color("blue")
t3.shape("turtle")
t3.goto(-60,-275)
t3.left(90)
t3.pendown()

t4 = turtle.Turtle()
t4.penup()
t4.color("purple")
t4.shape("turtle")
t4.goto(60,-275)
t4.left(90)
t4.pendown()

t5 = turtle.Turtle()
t5.penup()
t5.color("brown")
t5.shape("turtle")
t5.goto(180,-275)
t5.left(90)
t5.pendown()

t6 = turtle.Turtle()
t6.penup()
t6.color("yellow")
t6.shape("turtle")
t6.goto(300,-275)
t6.left(90)
t6.pendown()

line = turtle.Turtle()
line.penup()
line.goto(-325,350)
line.pendown()
line.forward(650)
line.hideturtle()


turtles = [t1,t2,t3,t4,t5,t6]

def turtleRace(turtles):
    global isCrossed
    for i in range(10):
        for j in range(len(turtles)):
            rndDis = random.randint(30,50)
            turtles[j].forward(rndDis)
            turtles[j].stamp()
            if turtles[j].ycor() >= 350:
                isCrossed = False
                break
        

isCrossed = False
while not isCrossed:
    turtleRace(turtles)

       



turtle.done()