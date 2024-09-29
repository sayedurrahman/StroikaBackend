import { useEffect, useState } from 'react';
import { useSelector, useDispatch } from 'react-redux';

import { fetchNationalities } from '../features/NationalitySlice';
import UserRole from '../components/UserRole';
import StudentList from '../components/StudentList';
import ParentComponent from '../components/ParentComponent';

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
            <ParentComponent />
        </div>
    );
}

export default HomePage;