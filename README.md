# Cybersecurity Awareness Chatbot (Part 2)

## Overview

The Cybersecurity Awareness Chatbot is a WPF desktop application developed in C# to educate users about important cybersecurity concepts and online safety practices. The chatbot provides an interactive user experience through a graphical user interface (GUI), personalised responses, voice greetings, memory recall, sentiment detection, and cybersecurity awareness tips.

The purpose of this project is to help users understand common cybersecurity threats and learn how to protect themselves while using digital technologies.

---

## Features

### Graphical User Interface (WPF)

* Professional cybersecurity-themed user interface
* Interactive chat window
* Modern design with responsive controls
* Welcome screen with cybersecurity branding

### Voice Greeting

* Custom recorded voice greeting using a WAV audio file
* Greeting automatically plays when the application starts

### User Interaction

* Prompts users for their name
* Personalised responses using the user's name
* Real-time conversation flow

### Cybersecurity Topics

The chatbot can provide information about:

* Password Safety
* Phishing Attacks
* Online Scams
* Malware
* Privacy Protection
* Two-Factor Authentication (2FA)

### Keyword Recognition

The chatbot recognises keywords entered by users and provides relevant cybersecurity advice.

### Random Responses

Multiple responses are stored for each topic. The chatbot randomly selects a response to create a more natural conversational experience.

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

and responds appropriately.

### Error Handling

The application validates user input and handles empty messages gracefully.

### Exit Functionality

Users can exit the chatbot by typing:

* exit
* quit
* bye

The chatbot provides a personalised farewell message before closing.

### Message Timestamps

All chat messages include timestamps to improve conversation tracking and usability.

---

## Technologies Used

* C#
* Windows Presentation Foundation (WPF)
* .NET 8
* Visual Studio 2022
* GitHub
* GitHub Actions

---

## GitHub Version Control

This project uses GitHub for version control. Multiple commits were made throughout development to track progress and maintain project history.

---

## Continuous Integration (CI)

GitHub Actions was implemented to automatically build the project whenever changes are pushed to the repository.

This helps ensure that the application remains stable and buildable throughout development.

---

## Future Improvements (Part 3 Development)

The following features are planned for the final version of the Cybersecurity Awareness Chatbot:

### Task Assistant with Reminders

* Allow users to create cybersecurity-related tasks.
* Add reminders for important security actions.
* Mark tasks as completed.
* View and manage saved tasks.

### Database Integration (MySQL)

* Store cybersecurity tasks in a MySQL database.
* Retrieve saved tasks when the application starts.
* Update and delete tasks directly from the GUI.
* Improve data persistence and organisation.

### Cybersecurity Quiz Mini-Game

* Introduce an interactive cybersecurity quiz.
* Include more than 10 questions covering cybersecurity concepts.
* Support multiple-choice and true/false questions.
* Track and display the user's final score.

### Enhanced NLP Simulation

* Improve the chatbot's ability to understand different ways users phrase questions.
* Recognise commands such as task creation, reminders, and quiz requests.
* Reduce unrecognised inputs through improved keyword matching.

### Activity Log System

* Record important chatbot actions.
* Track reminders, tasks, and quiz activity.
* Allow users to view recent chatbot actions through activity log commands.
* Display recent activities with timestamps.

### Improved User Experience

* Expand the graphical user interface with additional interactive controls.
* Enhance navigation between chatbot features.
* Improve responsiveness and usability of the application.

---

## Author

Mbuyelo Nkuna

---

## Acknowledgements

This project was developed as part of a Programming course and incorporates cybersecurity awareness concepts to promote safe online behaviour.
