# Internship-Assignment-3D-Character-Controller

I created this project with the SOLID Principles in mind. Below are some examples of how I implemented the SOLID Principles in the project.

1. I separated the logic part and UI part of every single component so the code does not break; if there is a bug in the UI, then it does not impact the working of the logic part.

2. Seprated the big functionality of Player Controller to separate scripts that handle their own logic without interfering with each other; for example, Player Movement, Collision, Health, and Animations all have their own scripts, so it helps to delegate big chunks of code to small parts.

3. Used the Singleton Pattern to remove the need to refer to different scirpts for different components if there is only one instance needed.
