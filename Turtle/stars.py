import turtle
import math
import random

t = turtle.Turtle()
t.getscreen().bgcolor("#994444")
t.speed(10)

t.penup()
t.goto((-200,100))
t.pendown()

def star(t, size):
    if size <= 10:
        return
    else:
        t.begin_fill()
        for i in range(5):
            t.fd(size)
            star(t, size/3)
            t.left(216)
        t.end_fill()

star(t, 360)

turtle.done()