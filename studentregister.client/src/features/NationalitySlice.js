import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";

// Initial state
const initialState = {
    nationalities: [],
    status: 'idle', // 'idle' | 'loading' | 'succeeded' | 'failed'
    error: null,
};

// Thunk to fetch students data
export const fetchNationalities = createAsyncThunk('nationalities/fetchNationalities', async () => {
    const response = await fetch('/core/api/nationalities'); 
    if (!response.ok) {
        throw new Error('Failed to fetch nationalities');
    }
    return response.json();
});

const nationalitySlice = createSlice({
    name: "nationalities",
    initialState,
    reducers: {},
    extraReducers: (builder) => {
        builder
            .addCase(fetchNationalities.pending, (state) => {
                state.status = 'loading';
            })
            .addCase(fetchNationalities.fulfilled, (state, action) => {
                state.status = 'succeeded';
                state.nationalities = action.payload;
            })
            .addCase(fetchNationalities.rejected, (state, action) => {
                state.status = 'failed';
                state.error = action.error.message;
            });
    }
});

export default nationalitySlice.reducer;