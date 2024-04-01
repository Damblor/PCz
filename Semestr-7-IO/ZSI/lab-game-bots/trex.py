import time
import pyautogui as pg
import keyboard as kb

def jump(seconds):
    pg.keyUp('Down')
    pg.keyDown('Up')
    time.sleep(seconds)
    pg.keyUp('Up')
    pg.keyDown('Down')
    

def main():
    time.sleep(3)
    kb.press('Space')
    while not kb.is_pressed('q'):
        if pg.pixel(814, 484)[0] == 83:
            jump(0.05)

if __name__ == "__main__":
    main()