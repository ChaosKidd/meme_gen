# 🚀 Meme Generator Web Application

## 📝 Project Overview

Meme Generator is a fun, interactive web application that allows users to create, customize, and download memes easily. Whether you're looking to express humor, creativity, or just have a good time, this application provides a simple and intuitive interface for meme creation.

### 🌟 Key Features
- Browse a wide selection of meme templates
- Add custom text to meme images
- Real-time meme preview
- Download and share your created memes
- User authentication
- Personal meme gallery

## 🛠 Technologies Used

- **Frontend**: HTML5, CSS, JavaScript
- **Backend**: Node.js, Express.js
- **Database**: Firebase Firestore
- **Authentication**: Firebase Authentication
- **Deployment**: Docker

## 📋 Prerequisites

Before you begin, ensure you have met the following requirements:

- Node.js (v16 or later)
- npm (v8 or later)
- Docker (optional, for containerized deployment)
- Firebase Account

## 🔧 Installation & Setup

### 1. Clone the Repository
```bash
git clone https://github.com/yourusername/meme-generator.git
cd meme-generator
```

### 2. Install Dependencies
```bash
npm install
```

### 3. Configure Firebase
1. Go to [Firebase Console](https://console.firebase.google.com/)
2. Create a new project
3. Enable Authentication and Firestore
4. Create a `.env` file in the project root with the following variables:
```
FIREBASE_API_KEY=your_api_key
FIREBASE_AUTH_DOMAIN=your_project.firebaseapp.com
FIREBASE_PROJECT_ID=your_project
FIREBASE_STORAGE_BUCKET=your_project.appspot.com
FIREBASE_MESSAGING_SENDER_ID=your_sender_id
FIREBASE_APP_ID=your_app_id
```

### 4. Run the Application
#### Development Mode
```bash
npm run dev
```

#### Production Mode
```bash
npm start
```

### 5. Docker Deployment (Optional)
```bash
# Build the Docker image
docker-compose build

# Run the container
docker-compose up
```

## 🧪 Running Tests
```bash
npm test
```

## 📦 Project Structure
```
meme-generator/
│
├── src/
│   ├── controllers/    # Business logic
│   ├── models/         # Data models
│   ├── routes/         # API routes
│   ├── views/          # HTML templates
│   └── public/         # Static assets
│
├── config/             # Configuration files
├── tests/              # Test suites
└── docker/             # Docker configurations
```

## 🤝 Contributing
Contributions are welcome! Please follow these steps:

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 🛡 Security
- Always keep your `.env` file secret
- Do not commit sensitive information to the repository
- Use strong, unique passwords
- Enable two-factor authentication on your accounts

## 📜 License
Distributed under the MIT License. See `LICENSE` for more information.

## 🙏 Acknowledgements
- [Firebase](https://firebase.google.com/)
- [Node.js](https://nodejs.org/)
- [Express.js](https://expressjs.com/)
- [ChaosKidd](https://github.com/ChaosKidd) - Front-End developer
- [Stochko](https://github.com/Stochko) - Front-End developer
- [Kristiyan](https://github.com/kriskata06) Stoykov - Full-Stack developer

---

**Happy Meme Making! 😄🚀**