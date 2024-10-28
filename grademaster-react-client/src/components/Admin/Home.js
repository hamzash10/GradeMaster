import React, { useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { logout } from '../../services/ApiCalls/auth';
import { Button, Container } from 'react-bootstrap';

const Home = () => {
    const navigate = useNavigate();

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