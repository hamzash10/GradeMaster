import React, { useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { isAuthenticated, logout } from '../../services/ApiCalls/auth';
import { Button, Container } from 'react-bootstrap';

const Home = () => {
    const navigate = useNavigate();

    useEffect(() => {
        if (!isAuthenticated()) {
            handleLogout()
        }
    }, [])

    const handleLogout = () => {
        logout()
        navigate('/Login')
    };

    return (
        <Container>
            <Button onClick={handleLogout}>
                logout
            </Button>
        </Container>
    );
};

export default Home;