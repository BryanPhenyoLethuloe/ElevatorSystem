# Elevator System

The Elevator System is a console application in C# that simulates the movement of elevators in a building with multiple floors and supports multiple elevators. The goal is to move people as efficiently as possible.

## Table of Contents

- [Description](#description)
- [Features](#features)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)

## Description

The Elevator System is implemented using object-oriented principles, following the DRY and SOLID principles. It consists of the following classes:

- `ElevatorSystem`: Represents the main elevator system and handles elevator movement and user interactions.
- `Elevator`: Represents an individual elevator and its functionalities.
- `Floor`: Represents a floor in the building and stores the number of people waiting on that floor.
- `Direction` (Enum): Represents the directions an elevator can move (Up, Down, or Stationary).

## Features

The console application provides the following features:

- Shows the status of each elevator, including their current floor, direction, and the number of people they are carrying.
- Supports multiple floors and multiple elevators.
- Allows setting the number of people waiting on each floor and calling elevators to specific floors.
- Implements a weight limit (number of people) for each elevator.

## Getting Started

### Prerequisites

- .NET SDK: Make sure you have .NET Core SDK installed on your machine.

### Installation

1. Clone the repository:

```bash
git clone https://github.com/your-username/ElevatorSystem.git
cd ElevatorSystem
