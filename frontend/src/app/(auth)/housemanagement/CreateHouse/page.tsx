import { Button } from '@/components/ui/button';
import { Card, CardContent, CardDescription, CardFooter, CardHeader, CardTitle } from '@/components/ui/card';
import { Input } from '@/components/ui/input';
import { Label } from '@/components/ui/label';
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from '@/components/ui/select';
import { Textarea } from '@/components/ui/textarea';
import React from 'react';

function House() {
    return (
        <div className="flex justify-center items-center h-full">
            <Card className="w-[400px]">
                <CardHeader>
                    <CardTitle>Create House</CardTitle>
                    <CardDescription></CardDescription>
                </CardHeader>
                <CardContent>
                    <form>
                        <div className="grid w-full items-center gap-4">
                            <div className="flex flex-col space-y-1.5">
                                <Label htmlFor="name">Name : </Label>
                                <Input type='text' id="name"/>
                            </div>
                            <div className="flex flex-col space-y-1.5">
                                <Label htmlFor="name">House Management : </Label>
                                <Input type='text' id="name"/>
                            </div>
                            <div className="flex flex-col space-y-1.5">
                                <Label htmlFor="Number">Number Of Rooms : </Label>
                                <Input type='number' id="Number"/>
                            </div>
                            <div className="flex flex-col space-y-1.5">
                                <Label htmlFor="Number">Price : </Label>
                                <Input type='number' id="Number"/>
                            </div>
                            <div className="flex flex-col space-y-1.5">
                                <Label htmlFor="Text">Description : </Label>
                                <Textarea placeholder="Type your message here." />
                            </div>
                        </div>
                    </form>
                </CardContent>
                <CardFooter className="flex justify-between">
                    <Button variant="outline">Cancel</Button>
                    <Button>Create</Button>
                </CardFooter>
            </Card>
        </div>
    )
}

export default House;