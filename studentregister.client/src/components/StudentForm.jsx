import React, { useEffect, useState } from 'react';
import { useSelector, useDispatch } from 'react-redux';

const StudentForm = (studentData) => {
    const [firstName, setFirstName] = useState('');
    const [lastName, setLastName] = useState('');
    const [dateOfBirth, setDob] = useState(new Date());

    //const role = useSelector((state) => state.userRole.role);
    //const dispatch = useDispatch();


    // Load student data when it becomes available
    useEffect(() => {
        if (studentData) {
            console.log(studentData)
            setFirstName(studentData.studentData.firstName || '');
            setLastName(studentData.studentData.lastName || '');
            setDob(studentData.studentData.dateOfBirth || new Date());
        }
    }, [studentData]);

    // Handle form submission
    const handleSubmit = (e) => {
        //e.preventDefault(); // Prevent page refresh

        //// Create an object with the form data
        //const formData = {
        //    firstName,
        //    lastName,
        //    dateOfBirth
        //};

        //console.log(formData);

        // Call the onSubmit prop function with the form data
        //if (onSubmit) {
        //    onSubmit(formData);
        //}
    };

    return (
        <form onSubmit={handleSubmit}>
            <label>
                First name:
                <input
                    value={firstName}
                    onChange={e => setFirstName(e.target.value)}
                />
            </label>
            <br />
            <label>
                Last name:
                <input
                    value={lastName}
                    onChange={e => setLastName(e.target.value)}
                />
            </label>
            <br />
            <label>
                Date Of Birth:
                <input
                    type="datetime-local"
                    value={dateOfBirth}
                    onChange={e => setDob(e.target.value)}
                />
            </label>
            <br />
            <button type="submit">Submit</button>

            {/*<p>*/}
            {/*    First Name: {firstName}, Last Name: {lastName} Date Of Birth: {dateOfBirth}*/}
            {/*</p>*/}
        </form>
    );
}

export default StudentForm;