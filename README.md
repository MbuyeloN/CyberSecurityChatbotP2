# Cybersecurity Awareness Chatbot

## Overview

The Cybersecurity Awareness Chatbot is a WPF desktop application developed in C# to educate users about important cybersecurity concepts and online safety practices. The chatbot provides an interactive user experience through a graphical user interface (GUI), personalised responses, voice greetings, memory recall, sentiment detection, cybersecurity awareness tips, task management, quiz functionality, database integration, and activity logging.

The purpose of this project is to help users understand common cybersecurity threats, improve cybersecurity awareness, and learn how to protect themselves while using digital technologies.

---

## Features

### Graphical User Interface (WPF)

* Professional cybersecurity-themed user interface
* Interactive chat window
* Modern design with responsive controls
* Welcome screen with cybersecurity branding
* Integrated chatbot, task assistant, quiz, and activity log functionality

### Voice Greeting

* Custom recorded voice greeting using a WAV audio file
* Greeting automatically plays when the application starts

### User Interaction

* Prompts users for their name
* Personalised responses using the user's name
* Real-time conversation flow

### Cybersecurity Topics

The chatbot provides information about:

* Password Safety
* Phishing Attacks
* Online Scams
* Malware
* Privacy Protection
* Two-Factor Authentication (2FA)

### Keyword Recognition and NLP Simulation

The chatbot recognises keywords entered by users and provides relevant cybersecurity advice.

The chatbot can understand and respond to:

* Cybersecurity-related questions
* Quiz requests
* Task management commands
* Reminder interactions
* Activity log requests

### Random Responses

Multiple responses are stored for each topic. The chatbot randomly selects responses to create a more natural and engaging conversation.

### Memory and Recall

The chatbot remembers the user's most recently discussed cybersecurity topic and can provide additional information when requested.

### Sentiment Detection

The chatbot identifies emotional keywords such as:

* Worried
* Scared
* Nervous
* Curious
* Frustrated
* Angry

and responds appropriately with supportive cybersecurity guidance.

### Error Handling

The application validates user input and handles empty messages gracefully.

### Exit Functionality

Users can exit the chatbot by typing:

* exit
* quit
* bye

The chatbot provides a personalised farewell message before closing.

### Message Timestamps

All chatbot messages include timestamps to improve conversation tracking and usability.

---

## Part 3 Features

### Task Assistant with Reminders

The chatbot includes a Task Assistant that allows users to create and manage cybersecurity-related tasks.

Users can:

* Add new tasks
* Include task descriptions
* Set reminders or timeframes
* Mark tasks as completed
* Delete tasks
* View saved tasks

### MySQL Database Integration

The application uses a MySQL database to provide persistent task storage.

Database features include:

* Saving tasks to a MySQL database
* Loading tasks when the application starts
* Updating completed tasks
* Deleting tasks from the database
* Synchronising task information between the GUI and database

### Cybersecurity Quiz Mini-Game

The chatbot includes an interactive cybersecurity quiz that helps users test their cybersecurity knowledge.

Features include:

* Multiple cybersecurity questions
* Score tracking
* Immediate feedback
* Educational cybersecurity content
* Interactive learning experience

### Activity Log System

The chatbot records important user actions and system activities.

Examples include:

* Task creation
* Task completion
* Task deletion
* Reminder activity
* Quiz interactions

Users can view recent activity by typing:

show activity

### Cohesive Integration

Parts 1, 2, and 3 have been successfully integrated into a single WPF application.

The final application combines:

* Cybersecurity chatbot
* Voice greeting
* NLP simulation
* Memory recall
* Sentiment detection
* Task Assistant
* Reminder system
* MySQL database integration
* Cybersecurity quiz
* Activity log

This creates a complete cybersecurity awareness assistant that both educates users and assists them with cybersecurity-related activities.

---

## Technologies Used

* C#
* Windows Presentation Foundation (WPF)
* .NET 8
* Visual Studio 2022
* MySQL Server
* MySQL Workbench
* MySql.Data NuGet Package
* GitHub
* GitHub Actions

---

## GitHub Version Control

This project uses GitHub for version control.

Development was tracked through multiple meaningful commits, allowing progress to be monitored throughout the project lifecycle.

Features were implemented incrementally and documented through commit history and release versions.

---

## GitHub Releases and Tags

The project includes multiple version tags and releases to demonstrate development progress.

Versions include:

* v1.0
* v1.1
* v1.2
* v2.1
* v2.2
* v2.3
* v2.4

Each release documents significant improvements and feature additions throughout development.

---

## Continuous Integration (CI)

GitHub Actions was implemented to automatically build the project whenever changes are pushed to the repository.

This ensures that the project remains stable, buildable, and properly tested throughout development.

---

## Video Demonstration

YouTube Video Link:

[Paste your YouTube video link here]

---

## Future Improvements

Possible future enhancements include:

* More advanced NLP capabilities
* Additional cybersecurity learning modules
* User authentication and profiles
* Enhanced reporting and analytics
* Cloud-based database integration
* Expanded cybersecurity quiz question bank

---

## Author

**Mbuyelo Nkuna**
