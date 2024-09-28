import { createSlice, createAsyncThunk } from '@reduxjs/toolkit';

// Define the async thunk for posting student data using fetch
export const addStudent = createAsyncThunk('students/addStudent',
    async (studentData, { rejectWithValue }) => {
        try {
            const response = await fetch('/core/api/students', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({
                    firstName: studentData.firstName.trim(),
                    lastName: studentData.lastName.trim(),
                    dateOfBirth: studentData.dateOfBirth, // Send only the date part
                }),
            });

            if (!response.ok) {
                throw new Error('Failed to add student');
            }

            const data = await response.json();
            return data; // Return the response data
        } catch (error) {
            return rejectWithValue(error.message); // Return error message if it fails
        }
    }
);

const studentSlice = createSlice({
    name: 'students',
    initialState: {
        students: [],
        status: 'idle',
        error: null,
    },
    reducers: {},
    extraReducers: (builder) => {
        builder
            .addCase(addStudent.pending, (state) => {
                state.status = 'loading';
            })
            .addCase(addStudent.fulfilled, (state, action) => {
                state.status = 'succeeded';
                state.students.push(action.payload); // Add the new student to the state
            })
            .addCase(addStudent.rejected, (state, action) => {
                state.status = 'failed';
                state.error = action.payload;
            });
    },
});

export default studentSlice.reducer;
