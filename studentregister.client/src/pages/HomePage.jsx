import { useEffect, useState } from 'react';
import { useSelector, useDispatch } from 'react-redux';
import { Link } from 'react-router-dom';
import { fetchNationalities } from '../features/NationalitySlice';
import UserRole from '../components/UserRole';
import StudentList from '../components/StudentList';

function HomePage() {
    const dispatch = useDispatch();
    const status = useSelector((state) => state.nationalities.status);

    // Store Nationality
    useEffect(() => {
        if (status === 'idle') {
            dispatch(fetchNationalities());
        }
    }, [status, dispatch]);


    return (
        <div>
            <UserRole />
            <StudentList />
            <Link to="/add-student">Add Student</Link>
        </div>
    );
}

export default HomePage;