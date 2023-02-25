# 2D-8-Ball-Pool-Clone-Game
I made a 8 Ball Pool Clone in Unity 2D
# 🎮 2D 8 Ball Pool Clone

# ⚙️ Install
Clone the project to your computer.
```
> git clone https://github.com/ArdaDenizKara/2D-8-Ball-Pool-Clone-Game.git
```
# 🎮 Main Menu Scene
in Main Menu , you can see there is a background and play button
if you click play button GamePlay Scene will be loaded. (Background made with Midjourney)
![image](https://user-images.githubusercontent.com/56769449/221361762-60acf392-7c02-4a2b-8ca0-bd1b328daabe.png)

# 🎮 GamePlay Scene
in GamePlay Scene , first Rack (Triangle contains balls) will spawn and will be destroyed after a second
![image](https://user-images.githubusercontent.com/56769449/221361868-eb940f75-9bec-4909-aec1-23b4950af0e1.png)

Then Player turn starts if player pockets the first ball with striped type stripe balls will be player's balls and solid balls will be opponents balls
if player pockets all balls , player has to pocket the 8 ball (black one) and then player wins. If player or opponent pocket the black ball before pocket all his balls other side wins the game.

# 📜 GamePlay Logic 
I instantiate balls and store them in Lists in BallManager 
![image](https://user-images.githubusercontent.com/56769449/221362140-985ff3af-2e83-4520-811a-103ab303acbd.png)

When the first ball pockets in player turn or opponent turn I added the ball type in PlayerBalls or OpponentBalls List , then whenever the ball collide I remove from the Lists . After the PlayerBalls or OpponentBalls List becomes empty and the black ball list is empty player or opponent wins.
![image](https://user-images.githubusercontent.com/56769449/221362313-c234dd2a-5e2f-4af7-9489-9fc73dc9624a.png)
