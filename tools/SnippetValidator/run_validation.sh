#!/bin/bash

# Script to run snippet validation and save results
echo "Running Snippet Validator Tool..."
echo "=================================="

cd "$(dirname "$0")"

# Build the tool first
echo "Building SnippetValidator..."
dotnet build --configuration Release > /dev/null 2>&1

if [ $? -ne 0 ]; then
    echo "Failed to build SnippetValidator"
    exit 1
fi

# Run the tool and save output
echo "Running validation (this may take several minutes)..."
OUTPUT_FILE="validation_results_$(date +%Y%m%d_%H%M%S).txt"

dotnet run --configuration Release > "$OUTPUT_FILE" 2>&1

echo "Validation complete. Results saved to: $OUTPUT_FILE"
echo ""
echo "Summary:"
ISSUE_COUNT=$(grep -c "Issue:" "$OUTPUT_FILE" 2>/dev/null || echo "0")
echo "Total issues found: $ISSUE_COUNT"

echo ""
echo "Sample issues (first 10):"
grep -A 1 -B 3 "Issue:" "$OUTPUT_FILE" | head -40

echo ""
echo "Full results available in: $OUTPUT_FILE"