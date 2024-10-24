import { React, useState, useEffect } from 'react';
import { BrowserRouter as Router, Route, Routes, Navigate } from 'react-router-dom';
import Register from './components/Auth/Register';
import Login from './components/Auth/Login';
import Home from './components/Admin/Home';

function App() {
    const [isfirst, setIsFirst] = useState(true);

    useEffect(() => {
        // Check if the user has already navigated
        if (isfirst) {
            setIsFirst(false);
        }
    }, [isfirst]);

    return (
        <Router>
            <Routes>
                <Route path="/" element={isfirst ? <Navigate to="/login" replace /> : <Navigate to="/home" replace />} />
                <Route path="/home" element={<Home />} />
                <Route path="/login" element={<Login />} />
                <Route path="/register" element={<Register />} />

            </Routes>
        </Router>
    );
}

export default App;
